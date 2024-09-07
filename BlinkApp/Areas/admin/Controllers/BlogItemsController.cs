using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlinkApp.DAL;
using BlinkApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlinkApp.Areas.admin.Controllers
{
    [Authorize(Roles ="admin")]
    [Area("admin")]
    public class BlogItemsController : Controller
    {
        private readonly HomeDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogItemsController(HomeDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: admin/BlogItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogItems.ToListAsync());
        }

        // GET: admin/BlogItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogItems = await _context.BlogItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogItems == null)
            {
                return NotFound();
            }

            return View(blogItems);
        }

        public IActionResult Create()
        {
            return View(new BlogItems());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogItems blogItems)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState)
                {
                    var errors = modelState.Value.Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
                    }
                }
                return View(blogItems);
            }

            //Img olub olmamasini ve olchusunun 500 den az olamsini yoxlayiriq
            if (!blogItems.Img.ContentType.Contains("image/") || blogItems.Img.Length / 1024 > 500)
            {
                ModelState.AddModelError("Img", "File is not valid");
                return View();
            }

            string path = _env.WebRootPath + @"\assets\images\blog";
            string filename = Guid.NewGuid().ToString() + blogItems.Img.FileName;
            string final = Path.Combine(path, filename).ToString();
            using (FileStream stream = new FileStream(final, FileMode.Create))
            {
                await blogItems.Img.CopyToAsync(stream);
            }

            blogItems.Image = filename;


            _context.Add(blogItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogItems = await _context.BlogItems.FindAsync(id);
            if (blogItems == null)
            {
                return NotFound();
            }
            return View(blogItems);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogItems blogItems)
        {
            if (id != blogItems.Id)
            {
                return NotFound();
            }
            //istifadəçi yeni şəkil upload etdib etməməsini yoxlayırıq
            if (blogItems.Img != null)
            {
                if (!blogItems.Img.ContentType.Contains("image/") || blogItems.Img.Length / 1024 > 500)
                {
                    ModelState.AddModelError("Img", "File is not valid");
                    return View();
                }
                //webrootpath istenilen serverdeki root pathi bize verir
                string path = _env.WebRootPath + @"\assets\images\blog";
                string filename = Guid.NewGuid().ToString() + blogItems.Img.FileName;
                string final = Path.Combine(path, filename).ToString();
                //köhnə image silirik
                if (System.IO.File.Exists(Path.Combine(path, blogItems.Image)))
                {
                    System.IO.File.Delete(Path.Combine(path, blogItems.Image));
                }

                using (FileStream stream = new FileStream(final, FileMode.Create))
                {
                    await blogItems.Img.CopyToAsync(stream);
                }
                //data bazadaki image e file name i set edirik
                blogItems.Image = filename;
            }
            
                try
                {
                    _context.Update(blogItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogItemsExists(blogItems.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
           

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogItems = await _context.BlogItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogItems == null)
            {
                return NotFound();
            }

            return View(blogItems);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogItems = await _context.BlogItems.FindAsync(id);
            string path = _env.WebRootPath + @"\assets\images\blog";
            string filename = blogItems.Image;
            string final = Path.Combine(path, filename).ToString();
            if (System.IO.File.Exists(final))
            {
                System.IO.File.Delete(final);
            }
            if (blogItems != null)
            {
                _context.BlogItems.Remove(blogItems);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogItemsExists(int id)
        {
            return _context.BlogItems.Any(e => e.Id == id);
        }
    }
}
