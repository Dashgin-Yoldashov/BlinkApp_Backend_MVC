using BlinkApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlinkApp.DAL
{
    public class HomeDbContext : IdentityDbContext<AppUser>
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) :base(options)
        {
            
        }
        public DbSet<About> About { get; set; }
        public DbSet<Achivement> Achivement { get; set; }
        public DbSet<AchivementItems> AchivementItems { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<AnalysisItem> AnalysisItems { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<BlogItems> BlogItems { get; set; }
        public DbSet<CustomerReviews> CustomerReviews { get; set; }
        public DbSet<CustomerReviewItems> CustomerReviewItems { get; set; }
        public DbSet<HeroArea> HeroArea { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
