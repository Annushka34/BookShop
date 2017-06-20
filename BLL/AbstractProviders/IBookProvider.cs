﻿using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractProviders
{
    public interface IBookProvider
    {
        BookUIModel CreateBook(BookCreateViewModel book);
        BookCreateUIModel GetCreateUIModel();      
    }
}