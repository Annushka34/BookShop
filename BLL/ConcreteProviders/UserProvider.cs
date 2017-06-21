﻿using System;
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
                userUILoginModel.BasketRecords = BasketRecordsCopy(basketRepository.GetBasketRecordsByBasket(newUser.Id));
                return userUILoginModel;
            }
            return null;
        }

        public List<UserUILoginModel> GetAllUsers()
        {
            List<UserUILoginModel> users=new List<UserUILoginModel>();
            if (users == null) return null;
            foreach (var user in _db.Users)
            {
                UserUILoginModel newUser=new UserUILoginModel();
                newUser.UserId = user.Id;
                newUser.UserLogin = user.Login;
                if (user.Customer == null)
                {
                    newUser.IsAdmin = true;
                    newUser.IsCustomer = false;
                }
                else
                {
                    newUser.IsCustomer = true;
                    newUser.IsAdmin = false;
                }
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
