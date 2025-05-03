using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemHomework.ViewModels.Author
{
    public class AuthorCreateVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
