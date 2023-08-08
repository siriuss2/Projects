namespace LibraryApp.ViewModels.AuthorViewModels
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
