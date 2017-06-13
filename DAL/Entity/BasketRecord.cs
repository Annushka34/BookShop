
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class BasketRecord
    {
        public BasketRecord()
        {
                Books=new List<Book>();
        }
        [Key]
        public int Id { get; set; }

        public virtual int BasketId { get; set; }
        [ForeignKey("BasketId")]
        public virtual Basket Basket { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
