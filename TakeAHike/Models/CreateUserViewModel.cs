using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeAHike.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "You must provide a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide an email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a password.")]
        public string Password { get; set; }


    }
    
}
