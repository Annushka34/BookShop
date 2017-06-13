using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Publish
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
