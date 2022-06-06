using System.ComponentModel.DataAnnotations;

namespace Electronics.Auth.Model.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "You have missed to fill the username")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
