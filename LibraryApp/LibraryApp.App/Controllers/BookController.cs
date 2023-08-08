using LibraryApp.Services.Interfaces;
using LibraryApp.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.App.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;

        public BookController(IBookService _bookService, IAuthorService _authorService)
        {
            this._bookService = _bookService;
            this._authorService = _authorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetAllBooks());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _bookService.GetBookDetails(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _bookService.DeleteBookById(id));
        }

        public async Task<IActionResult> Create()
        {
            BookViewModel bookViewModel = new BookViewModel();
            ViewBag.Authors = await _authorService.GetAuthorsForDropdown();

            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            await _bookService.AddBook(bookViewModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            BookViewModel bookViewModel = await _bookService.GetBookForEditing(id);
            ViewBag.Authors = await _authorService.GetAuthorsForDropdown();

            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel bookViewModel)
        {
            await _bookService.EditBook(bookViewModel);
            return RedirectToAction("Index");
        }
    }
}
