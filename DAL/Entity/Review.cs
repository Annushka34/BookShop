using System;
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
        public int BookId { get; set; }
        [ForeignKey("bookId")]
        public virtual Book Book { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Cuctomer { get; set; }

    }
}
