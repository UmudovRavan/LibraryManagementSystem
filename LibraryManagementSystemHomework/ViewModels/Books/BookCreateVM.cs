using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemHomework.ViewModels.Books
{
    public class BookCreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublishedYear { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Kateqoriya mütləq seçilməlidir")]
        public int BookCategoryId { get; set; }
        

        [Required]
        public int PublisherId { get; set; }
       
    }
}
