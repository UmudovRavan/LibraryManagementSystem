namespace LibraryManagementSystemHomework.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
