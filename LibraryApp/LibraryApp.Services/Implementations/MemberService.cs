using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using LibraryApp.Mappers;
using LibraryApp.Services.Interfaces;
using LibraryApp.ViewModels.MemberViewModels;

namespace LibraryApp.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private IRepository<Member> _memberRepository;
        public MemberService(IRepository<Member> _memberRepository)
        {
            this._memberRepository = _memberRepository;
        }
        public async Task<List<MemberListViewModel>> GetAllMembers()
        {
            List<Member> memberDb = await _memberRepository.GetAll();
            return memberDb.Select(x => x.ToMemberListViewModel()).ToList();
        }

        public async Task<MemberDetailsViewModel> GetMemberDetails(int id)
        {
            Member memberDb = await _memberRepository.GetById(id);
            return memberDb.ToMemberDetailsViewModel();
        }
    }
}
