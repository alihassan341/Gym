using System.ComponentModel.DataAnnotations;

namespace Gym_Management_System.Entities
{
    public class Login : BaseDto<long>
    {
        [Required(ErrorMessage = "UserName Is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string? Password { get; set; }
        [EmailAddress]
        //[Required(ErrorMessage = "Email Is Required")]
        public string? Email { get; set; }
        public string? DataBaseName { get; set; }
        public string? DataBasePassword { get; set; }
        public string? Token { get; set; }// = string.Empty;
    }
}

