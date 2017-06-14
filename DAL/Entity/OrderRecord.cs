using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class OrderRecord
    {
       
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book{ get; set; }
    }
}
