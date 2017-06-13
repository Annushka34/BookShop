
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Order
    {
        public Order()
        {
            OrderRecords=new List<OrderRecord>();
        }
        [Key, ForeignKey("Customer")]
        public int Id { get; set; }

        public virtual ICollection<OrderRecord> OrderRecords  { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Cuctomer { get; set; }
    }
}
