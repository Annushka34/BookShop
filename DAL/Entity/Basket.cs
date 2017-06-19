using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Basket
    {
        [Key, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        //public DateTime TimePurchase { get; set; }
        public virtual ICollection<BasketRecord> BasketRecords { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
