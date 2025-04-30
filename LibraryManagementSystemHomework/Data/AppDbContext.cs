using LibraryManagementSystemHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemHomework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorContact> AuthorContact { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
