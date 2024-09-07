using BlinkApp.DAL;
using BlinkApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlinkApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly HomeDbContext db;

        public BlogController(HomeDbContext _db)
        {
            db = _db;
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
        public async Task<IActionResult> BlogGrid()
        {
            List<BlogItems> blogs = await db.BlogItems.Take(3).ToListAsync();
            return View(blogs);
        }
        public async Task<IActionResult> Pagenation(int skip)
        {
            return PartialView("_BlogPartial", await db.BlogItems.Skip(skip).Take(3).ToListAsync());
        }
        public async Task<IActionResult> Message(string comment, string name,string email)
        {
            Message messages = new Message()
            {
                Comment =comment,
                Name = name,
                Email = email
            };
            db.Messages.Add(messages);
            await db.SaveChangesAsync();
            return RedirectToAction();
        }
    }
}
