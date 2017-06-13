using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Customer
    {
     
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews{ get; set; }

    }
}
