using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class OrderRecord
    {
        [Key]
        int Id { get; set; }
        public int Count { get; set; }
      
        //зв'язок один до багатьох для ордера і книги
    }
}
