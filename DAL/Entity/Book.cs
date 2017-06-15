using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            Tags = new HashSet<Tag>();
            Categories = new HashSet<Category>();           
        }

        [Key]
        public int Id { get; set; }
        public int Isbn { get; set; }
        public double Price { get; set; }
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 600)]
        public string Description { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<OrderRecord> OrderRecords { get; set; }
        public virtual ICollection<BasketRecord> BasketRecords { get; set; }
        public virtual Picture Picture { get; set; }
        public int PublishId { get; set; }
        [ForeignKey("PublishId")]
        public virtual Publish Publish { get; set; }


    }
}
