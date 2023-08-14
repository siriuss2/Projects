using LibraryApp.Domain.Enums;

namespace LibraryApp.ViewModels.MemberViewModels
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MembershipID { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public MembershipStatusEnum MembershipStatus { get; set; }
    }
}
