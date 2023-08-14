using LibraryApp.ViewModels.MemberViewModels;

namespace LibraryApp.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<MemberListViewModel>> GetAllMembers();
        Task<MemberDetailsViewModel> GetMemberDetails(int id);
    }
}
