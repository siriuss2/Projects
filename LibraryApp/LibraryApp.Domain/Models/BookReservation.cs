namespace LibraryApp.Domain.Models
{
    public class BookReservation : BaseEntity
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set;}
    }
}
