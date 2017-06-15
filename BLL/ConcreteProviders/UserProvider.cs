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

namespace BLL.ConcreteProviders
{
    public class UserProvider : IUserProvider
    {
        MyContext _db;
        public UserProvider()
        {
            _db = new MyContext();
        }
        public UserStatus UserCreate(UserViewModel user)
        {
            User newUser = new User();
            newUser.Login = user.Login;

            string salt = 
            newUser.Password = user.Password;
            newUser.Email = user.Email;
            
            IUserRepository userRepository = new UserRepository(_db);
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
                        customerRepository.CreateCustomer(newUser);
                    }
                    transaction.TransactionCommit();
                    return UserStatus.Success;
                }
                catch
                {
                    transaction.Dispose();
                    return UserStatus.DublicationEmail;
                }
            }
            
            
        }
    }
}    
     