using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Picture
    {
        [Key]
        int Id { get; set; }
        public string PicturePath { get; set; }
       
        //зв'язок один до одного для книги
    }
}
