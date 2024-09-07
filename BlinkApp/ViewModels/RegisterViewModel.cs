using System.ComponentModel.DataAnnotations;

namespace BlinkApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength(50)]
        public string Surname { get; set; }
        [Required,EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required,MinLength(8),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,MinLength(8),DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
