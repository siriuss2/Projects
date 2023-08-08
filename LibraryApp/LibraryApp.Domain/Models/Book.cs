using LibraryApp.Domain.Enums;

namespace LibraryApp.Domain.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string Synopsis { get; set; } = string.Empty;
        public Author Author { get; set; } 
        public int AuthorId { get; set; }
        public List<BookReservation> BookReservations { get; set; } = new List<BookReservation>();
    }
}
