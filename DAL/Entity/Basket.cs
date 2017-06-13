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
        public Basket()
        {
            BasketRecords = new List<BasketRecord>();
        }
        [Key, ForeignKey("Customer")]
        public int Id { get; set; }

        public ICollection<BasketRecord> BasketRecords { get; set; }
        public Customer Customer { get; set; }
    }
}
