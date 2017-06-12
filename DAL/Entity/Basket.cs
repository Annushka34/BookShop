using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Basket
    {
        [Key]
        int Id { get; set; }
    }
}
