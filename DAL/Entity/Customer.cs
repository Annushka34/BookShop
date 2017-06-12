using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Customer
    {
        [Key]
        int Id { get; set; }
    }
}
