namespace LibraryManagementSystemHomework.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }
        public decimal Price { get; set; }
        public int BookCategoryId { get; set; }
        public int PublisherId { get; set; }
        public BookCategory BookCategory { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthors> BookAuthors { get; set; }

    }
}
