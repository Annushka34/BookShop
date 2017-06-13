using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public  class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public virtual ICollection<Book> Books { get; set; }
    }
}
