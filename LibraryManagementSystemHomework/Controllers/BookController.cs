using LibraryManagementSystemHomework.Data;
using LibraryManagementSystemHomework.Models;
using LibraryManagementSystemHomework.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartMapValidator;

namespace LibraryManagementSystemHomework.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;

        public BookController(IWebHostEnvironment env, AppDbContext appDbContext)
        {
            _env = env;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var book = await _appDbContext.Books.ToListAsync();
            return View(book);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.BookCategories = new SelectList(_appDbContext.BookCategories.ToList(), "Id", "Name");
            ViewBag.Publishers = new SelectList(_appDbContext.Publisher.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BookCategories = new SelectList(_appDbContext.BookCategories.ToList(), "Id", "Name");
                ViewBag.Publisher = new SelectList(_appDbContext.Publisher.ToList(), "Id", "Name");
                return View(model);
               
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Price <= 0)
            {
                ModelState.AddModelError("Price", "Mebleg 0-dan kicik ola bilmez");
                return View(model);
            }
            if (model.BookCategoryId == 0)
            {
                ModelState.AddModelError("BookCategoryId", "Kitab kateqoriyasi secin");
                return View(model);
            }
            Book book = new Book
            {
                Title = model.Title,
                PublishedYear = model.PublishedYear,
                Price = model.Price,
                BookCategoryId = model.BookCategoryId,
                PublisherId= model.PublisherId

            };

            await _appDbContext.Books.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
                 return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _appDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return NotFound();

            return View(book); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _appDbContext.Books.FindAsync(id);
            if (book == null) return NotFound();

            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _appDbContext.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null) return NotFound();

           
            var categories = await _appDbContext.BookCategories.ToListAsync();
            ViewBag.BookCategories = new SelectList(categories, "Id", "Name");

            var data = new BookEditVM
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                PublishedYear = book.PublishedYear,
                BookCategoryId = book.BookCategoryId
            };

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookEditVM request)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _appDbContext.BookCategories.ToListAsync();
                ViewBag.BookCategories = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var book = await _appDbContext.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null) return NotFound();

            book.Title = request.Title;
            book.Price = request.Price;
            book.PublishedYear = request.PublishedYear;
         
            _appDbContext.Update(book);
            await _appDbContext.SaveChangesAsync();

            TempData["success"] = "Kitab uğurla yeniləndi";
            return RedirectToAction("Index"); 
        }
    }
}
