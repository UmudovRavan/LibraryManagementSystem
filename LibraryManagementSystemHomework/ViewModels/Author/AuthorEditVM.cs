using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemHomework.ViewModels.Author
{
    public class AuthorEditVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
