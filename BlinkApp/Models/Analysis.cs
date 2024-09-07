using System.ComponentModel.DataAnnotations.Schema;

namespace BlinkApp.Models
{
    public class Analysis:BaseEntity
    {
        [NotMapped]
        public IFormFile Img{ get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
