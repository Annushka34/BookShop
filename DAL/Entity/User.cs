using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Login { get; set; }
        [StringLength(maximumLength: 16)]
        public string Password { get; set; }
        [StringLength(maximumLength:100)]
        [EmailAddress]
        public string Email { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
