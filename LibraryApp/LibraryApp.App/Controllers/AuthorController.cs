using LibraryApp.Services.Interfaces;
using LibraryApp.ViewModels.AuthorViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.App.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService _authorService)
        {
            this._authorService = _authorService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _authorService.GetAllAuthors());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _authorService.GetAuthorDetails(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _authorService.DeleteAuthorById(id));
        }

        public IActionResult Create()
        {
            AuthorViewModel authorViewModel = new AuthorViewModel();
            return View(authorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorViewModel authorViewModel)
        {
            await _authorService.AddAuthor(authorViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            AuthorViewModel authorViewModel = await _authorService.GetAuthorForEditing(id);
            return View(authorViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(AuthorViewModel authorViewModel)
        {
            await _authorService.EditAuthor(authorViewModel);
            return RedirectToAction("Index");
        }
    }
}
