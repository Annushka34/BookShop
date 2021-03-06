﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
   public class Review
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        [Range(1, 5)]
        public int BookQuality { get; set; }
        [StringLength(maximumLength: 500)]
        public string ReviewDescription { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
