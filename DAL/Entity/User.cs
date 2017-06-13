using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class User
    {
        [Key]
        int Id { get; set; }

        [StringLength(maximumLength: 100)]
        string Login { get; set; }

        [StringLength(maximumLength: 16)]
        string Password { get; set; }

        [StringLength(maximumLength:100)]
        [EmailAddress]
        string Email { get; set; }
    }
}
