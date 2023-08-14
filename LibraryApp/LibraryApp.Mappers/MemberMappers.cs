using LibraryApp.Domain.Models;
using LibraryApp.ViewModels.MemberViewModels;

namespace LibraryApp.Mappers
{
    public static class MemberMappers
    {
        public static MemberListViewModel ToMemberListViewModel(this Member member)
        {
            return new MemberListViewModel
            {
                Id = member.Id,
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                MembershipStatus = member.MembershipStatus
            };
        }

        public static MemberDetailsViewModel ToMemberDetailsViewModel(this Member member)
        {
            return new MemberDetailsViewModel
            {
                Id = member.Id,
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                MembershipID = member.MembershipID,
                MembershipStatus = member.MembershipStatus,
            };
        }
    }
}
