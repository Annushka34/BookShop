
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class BasketRecord
    {
        
        [Key]
        public int Id { get; set; }

        public virtual int BasketId { get; set; }
        [ForeignKey("BasketId")]
        public virtual Basket Basket { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
