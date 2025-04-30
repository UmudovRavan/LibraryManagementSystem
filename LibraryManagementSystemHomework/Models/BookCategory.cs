namespace LibraryManagementSystemHomework.Models
{
    public class BookCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
