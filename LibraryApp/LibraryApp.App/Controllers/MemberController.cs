using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.App.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;

        public MemberController(IMemberService _memberService)
        {
            this._memberService = _memberService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _memberService.GetAllMembers());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _memberService.GetMemberDetails(id));
        }
    }
}
