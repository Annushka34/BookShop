using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public UserUILoginModel UserLogin(UserViewModelLogin user)
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
                IBasketRepository basketRepository = new BasketRepository(_db);
                UserUILoginModel userUILoginModel = new UserUILoginModel(newUser);
                userUILoginModel.BasketRecordsCount = basketRepository.GetBasketRecordsByBasket(newUser.Id).Count;
                return userUILoginModel;
            }
            return null;
        }

        public List<UserUILoginModel> GetAllUsers()
        {
            IUserRepository userRepository = new UserRepository(_db);
            ICustomerRepository customerRepository = new CustomerRepository(_db);
            IAdminRepository adminRepository = new AdminRepository(_db);
            IBasketRepository basketRepository=new BasketRepository(_db);

            List<UserUILoginModel> users=new List<UserUILoginModel>();
            List<User> usersfromdb = _db.Users.ToList();
            foreach (var user in usersfromdb)
            {
                UserUILoginModel newUser=new UserUILoginModel();
                newUser.UserId = user.Id;
                newUser.UserLogin = user.Login;
                newUser.IsCustomer = false;
                newUser.IsAdmin = false;
                if (customerRepository.GetCustomerById(user.Id)!=null)
                    newUser.IsCustomer = true;
                if(adminRepository.GetAdminById(user.Id)!=null)
                    newUser.IsAdmin = true;
                newUser.BasketRecordsCount = basketRepository.GetBasketRecordsByBasket(user.Id).Count;
                users.Add(newUser);
            }
            return users;
        }

        public List<BasketRecordUIModel> BasketRecordsCopy(List<BasketRecord> basketRecords)
        {
            List<BasketRecordUIModel> basketRecordUIModel = new List<BasketRecordUIModel>();
            IBookRepository bookRepository = new BookRepository(_db);
            foreach (var basketRecord in basketRecords)
            {
                BasketRecordUIModel tempBasketRecordUIModel = new BasketRecordUIModel();
                tempBasketRecordUIModel.Id = basketRecord.Id;
                tempBasketRecordUIModel.BookName = bookRepository.GetBookById(basketRecord.BookId).Name;
                tempBasketRecordUIModel.Count = basketRecord.Count;
                basketRecordUIModel.Add(tempBasketRecordUIModel);
            }
            return basketRecordUIModel;
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
