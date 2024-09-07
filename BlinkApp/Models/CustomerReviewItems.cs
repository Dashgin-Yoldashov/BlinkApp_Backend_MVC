using System.ComponentModel.DataAnnotations.Schema;

namespace BlinkApp.Models
{
    public class CustomerReviewItems : BaseEntity
    {
        public string Review { get; set; }
        public string Name { get; set; }
        public string Work { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        public string Image { get; set; }
    }
}
