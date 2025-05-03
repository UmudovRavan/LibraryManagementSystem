using LibraryManagementSystemHomework.Data;
using LibraryManagementSystemHomework.Models;
using LibraryManagementSystemHomework.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemHomework.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;
        public AuthorController(IWebHostEnvironment env,AppDbContext appDbContext)
        {
            _env = env;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var author = await _appDbContext.Author.ToListAsync();
            return View(author);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Author author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateofBirth
            };
            await _appDbContext.Author.AddAsync(author);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var author = await _appDbContext.Author.FirstOrDefaultAsync(m=>m.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            var data = new AuthorEditVM
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorEditVM request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            var author = await _appDbContext.Author.FirstOrDefaultAsync(m => m.Id == id);
            if (author == null) { return NotFound(); };

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.DateOfBirth = request.DateOfBirth;   

            _appDbContext.Update(author);
            await _appDbContext.SaveChangesAsync();

            TempData["success"] = "Author ugurla yaradildi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            ;
            var author = _appDbContext.Author.FirstOrDefault(m => m.Id == id);
            if (author == null) { return NotFound(); };
            return View(author);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _appDbContext.Author.FirstOrDefaultAsync(m=>m.Id == id);
            if (author == null) { return NotFound();; };

            _appDbContext.Author.Remove(author);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
