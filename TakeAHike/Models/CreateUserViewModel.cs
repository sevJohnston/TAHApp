using System.ComponentModel.DataAnnotations;


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
