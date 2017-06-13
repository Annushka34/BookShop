using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
   public class Review
    {
        [Key]
        int Id { get; set; }

        [Range(1,5)]
        public int BookQuality { get; set; }

        [StringLength(maximumLength: 500)]
        public string ReviewDescription { get; set; }
        
        //зв'язок 1 до багатьох для кастомера
    }
}
