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
        public Customer()
        {
            Reviews=new List<Review>();
            Orders=new List<Order>();
        }
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public Basket Basket { get; set; }

        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews{ get; set; }

    }
}
