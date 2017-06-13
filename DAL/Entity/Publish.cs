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
        int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        //зв'язок до книги один до багатьох

    }
}
