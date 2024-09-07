using BlinkApp.DAL;
using BlinkApp.Models;
using BlinkApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlinkApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeDbContext db;

        public HomeController(HomeDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                HeroArea = await db.HeroArea.ToListAsync(),
                Pricings = await db.Pricings.ToListAsync(), 
                Services = await db.Services.ToListAsync(),
                CustomerReviews = await db.CustomerReviews.ToListAsync(),
                CustomerReviewItems = await db.CustomerReviewItems.ToListAsync(),
                Blogs = await db.Blogs.ToListAsync(),
                BlogItems = await db.BlogItems.ToListAsync(), 
                Analysis = await db.Analysis.ToListAsync(),
                AnalysisItems = await db.AnalysisItems.ToListAsync(),
                Achivement = await db.Achivement.ToListAsync(),
                AchivementItems = await db.AchivementItems.ToListAsync(),
                About = await db.About.ToListAsync(),
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
