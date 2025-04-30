namespace LibraryManagementSystemHomework.Models
{
    public class BookAuthors : BaseEntity
    {
        public int BooksId { get; set; }
        public int AuthorsId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
