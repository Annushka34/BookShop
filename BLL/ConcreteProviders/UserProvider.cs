using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.AbstractProviders;
using BLL.ViewModels;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;
using DAL.Entity;
using SimpleCrypto;

namespace BLL.ConcreteProviders
{
    public class UserProvider : IUserProvider
    {
        MyContext _db;
        public UserProvider()
        {
            _db = new MyContext();
        }

        public UserUIDataModel UserLogin(UserViewModelLogin user)
        {
            IUserRepository userRepository = new UserRepository(_db);

            User newUser = userRepository.GetUserByLogin(user.Login);
            if (newUser == null)
            {
                return null;
            }

            ICryptoService cryptoService = new PBKDF2();
            string hashPassword2 = cryptoService.Compute(user.Password, newUser.PasswordSalt);
            if (cryptoService.Compare(newUser.Password, hashPassword2))
            {
                UserUIDataModel userModel = new UserUIDataModel(newUser);
                return userModel;
            }
            return null;
        }

        public UserStatus UserRegistration(UserViewModel user)
        {
            IUserRepository userRepository = new UserRepository(_db);

            //перевірка на вже існуючого користувача

            User newUser = userRepository.GetUserByLogin(user.Login);
            if(newUser!=null)
            {
                return UserStatus.DublicationLogin;
            }

            newUser = new User();
            newUser.Login = user.Login;

            //шифрування пароля

            ICryptoService cryptoService = new PBKDF2();
            newUser.PasswordSalt = cryptoService.GenerateSalt();
            newUser.Password = cryptoService.Compute(user.Password);
            
            newUser.Email = user.Email;

            using (Transaction transaction = new Transaction())
            {
                try
                {
                    transaction.TransactionStart();
                    userRepository.CreateUser(newUser);
                    if (user.Role == UserRole.Admin)
                    {
                        IAdminRepository adminRepository = new AdminRepository(_db);
                        adminRepository.CreateAdmin(newUser);
                    }
                    else
                    {
                        ICustomerRepository customerRepository = new CustomerRepository(_db);
                        Customer cutomer = customerRepository.CreateCustomer(newUser);

                        IBasketRepository basketRepository = new BasketRepository(_db);
                        basketRepository.CreateBasket(cutomer);
                    }
                    transaction.TransactionCommit();
                    return UserStatus.Success;
                }
                catch
                {
                    transaction.Dispose();
                    return UserStatus.TransactionDispose;
                }
            }
        }
    }
}
