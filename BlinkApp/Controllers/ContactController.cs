using BlinkApp.DAL;
using BlinkApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlinkApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly HomeDbContext db;

        public ContactController(HomeDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Send(string name,string subject,string email,string message)
        {
            Contact contact = new Contact()
            {
                Name= name,
                Subject= subject,
                Email= email,
                Message= message
            };
            await db.Contacts.AddAsync(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
