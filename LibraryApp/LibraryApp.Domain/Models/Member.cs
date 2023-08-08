using LibraryApp.Domain.Enums;

namespace LibraryApp.Domain.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int MembershipID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public MembershipStatusEnum MembershipStatus { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
