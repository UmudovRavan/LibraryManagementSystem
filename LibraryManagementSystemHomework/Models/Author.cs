namespace LibraryManagementSystemHomework.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AuthorContact AuthorContact { get; set; }
        public ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
