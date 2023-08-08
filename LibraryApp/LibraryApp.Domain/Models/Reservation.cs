using LibraryApp.Domain.Enums;

namespace LibraryApp.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public string BookTitle { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public ReservationStatusEnum ReservationStatus { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public List<BookReservation> BookReservations { get; set; }

    }
}
