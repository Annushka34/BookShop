﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class OrderRecord
    {
        public OrderRecord()
        {
                Books=new List<Book>();
        }
        [Key]
        public int Id { get; set; }

        public virtual int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
