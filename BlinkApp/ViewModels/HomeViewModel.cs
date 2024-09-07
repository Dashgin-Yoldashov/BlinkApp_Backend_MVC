using BlinkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlinkApp.ViewModels
{
    public class HomeViewModel
    {
        public List<About> About { get; set; }
        public List<Achivement> Achivement { get; set; }
        public List<AchivementItems> AchivementItems { get; set; }
        public List<Analysis> Analysis { get; set; }
        public List<AnalysisItem> AnalysisItems { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<BlogItems> BlogItems { get; set; }
        public List<CustomerReviews> CustomerReviews { get; set; }
        public List<CustomerReviewItems> CustomerReviewItems { get; set; }
        public List<HeroArea> HeroArea { get; set; }
        public List<Pricing> Pricings { get; set; }
        public List<Services> Services { get; set; }
    }
}
