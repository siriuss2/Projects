namespace LibraryApp.ViewModels.BookViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
    }
}
