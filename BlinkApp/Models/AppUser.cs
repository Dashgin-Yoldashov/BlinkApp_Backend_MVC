using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlinkApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
