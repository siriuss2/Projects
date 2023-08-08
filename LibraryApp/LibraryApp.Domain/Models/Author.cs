namespace LibraryApp.Domain.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
        public string Biography { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public int BooksPublished { get; set; }

    }
}
