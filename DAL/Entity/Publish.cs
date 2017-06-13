﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Publish
    {
        public Publish()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
