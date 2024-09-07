using System.ComponentModel.DataAnnotations.Schema;

namespace BlinkApp.Models
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string IconName { get; set; }
        public string IconText { get; set; }

        [NotMapped]
        public IFormFile Img { get; set; }
        public string Image { get; set; }
    }
}
