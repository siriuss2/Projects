using System.ComponentModel.DataAnnotations;

namespace LibraryApp.ViewModels.AuthorViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name:")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Lastname:")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Nationality:")]
        public string Nationality { get; set; } = string.Empty;

        [Display(Name = "Enter image url:")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Add Biography:")]
        public string Biography { get; set; } = string.Empty;

        [Display(Name = "Date of birth:")]
        public string BirthDate { get; set; } = string.Empty;

        [Display(Name = "Enter number of books published:")]
        public int BooksPublished { get; set; }
    }
}
