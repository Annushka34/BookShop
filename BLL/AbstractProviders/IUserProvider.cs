﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;

namespace BLL.AbstractProviders
{
    public interface IUserProvider
    {
        UserStatus UserCreate(UserViewModel user);
    }
}