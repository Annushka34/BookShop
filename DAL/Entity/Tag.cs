using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
   public class Tag
    {
        [Key]
        int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        //зв'язок багато до багатьох для книги


    }
}
