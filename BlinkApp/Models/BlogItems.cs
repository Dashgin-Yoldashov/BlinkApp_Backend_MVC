using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlinkApp.Models
{
    public class BlogItems : BaseEntity
    {
        [NotMapped]
        public IFormFile Img { get; set; }

        [StringLength(500),Required]
        public string Image { get; set; }

        [Required]
        public string Blog { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string ReadMoreLink { get; set; }
    }
}
