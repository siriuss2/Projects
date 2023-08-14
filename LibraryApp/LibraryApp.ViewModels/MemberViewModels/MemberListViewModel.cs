using LibraryApp.Domain.Enums;

namespace LibraryApp.ViewModels.MemberViewModels
{
    public class MemberListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public MembershipStatusEnum MembershipStatus { get; set; }

    }
}
