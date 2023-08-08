namespace LibraryApp.ViewModels.AuthorViewModels
{
    public class AuthorDetailsViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public int BooksPublished { get; set; }
    }
}
