using LibraryApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.ViewModels.BookViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Pick a genre")]
        public Genre Genre { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; } = string.Empty;

        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Synopsis")]
        public string Synopsis { get; set; } = string.Empty;

        [Display(Name = "Choose Author")]
        public int AuthorId { get; set; }
    }
}
