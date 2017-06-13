using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 100)]
        public string LastName { get; set; }
        [StringLength(maximumLength: 100)]
        public DateTime autorbirthdate { get; set;}
        public DateTime autordeathdate { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}


