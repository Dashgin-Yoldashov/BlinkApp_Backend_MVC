using System.ComponentModel.DataAnnotations;

namespace BlinkApp.Models
{
    public class Contact :BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength(80)]
        public string Subject { get; set; }
        [Required,EmailAddress,MaxLength(50)]
        public string Email { get; set; }
        [Required,MaxLength(250)]
        public string Message { get; set; }
    }
}
