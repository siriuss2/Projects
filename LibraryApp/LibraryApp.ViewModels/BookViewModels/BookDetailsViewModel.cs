using LibraryApp.Domain.Enums;

namespace LibraryApp.ViewModels.BookViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public string AuthorFullName { get; set; }
    }
}
