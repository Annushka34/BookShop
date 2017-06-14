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

namespace BLL.ConcreteProviders
{
    public class UserProvider:IUserProvider
    {
        public UserStatus UserCreate(UserViewModel user)
        {
            User newUser=new User();
            newUser.Login = user.Login;
            newUser.Password = user.Password;
            newUser.Email = user.Email;
            IUserRepository userRepository=new UserRepository();
            bool isCreated=userRepository.Create(newUser);
            if(isCreated)return UserStatus.Success;
            return UserStatus.DublicationEmail;
        }
    }
}