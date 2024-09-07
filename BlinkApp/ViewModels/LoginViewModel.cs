using System.ComponentModel.DataAnnotations;

namespace BlinkApp.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool StayLogedIn { get; set; }
    }
}
