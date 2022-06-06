using System.ComponentModel.DataAnnotations;

namespace Electronics.Auth.Model.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "You have missed to fill the username")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You have missed to fill the Pass")]
        public string Password { get; set; }
    }
}
