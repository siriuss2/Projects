using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using LibraryApp.Mappers;
using LibraryApp.Services.Interfaces;
using LibraryApp.ViewModels.BookViewModels;

namespace LibraryApp.Services.Implementations
{
    public class BookService : IBookService
    {
        private IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> _bookRepository)
        {
            this._bookRepository = _bookRepository;
        }

        public Task AddBook(BookViewModel bookViewModel)
        {
            return _bookRepository.Insert(bookViewModel.ToBook());
        }

        public async Task<int> DeleteBookById(int id)   
        {
            return await _bookRepository.DeleteById(id);
        }

        public async Task EditBook(BookViewModel bookViewModel)
        {
            Book bookDb = await _bookRepository.GetById(bookViewModel.Id) ?? throw new Exception("Book not found");

            bookDb.Id = bookViewModel.Id;
            bookDb.Title = bookViewModel.Title;
            bookDb.Synopsis = bookViewModel.Synopsis;
            bookDb.ISBN = bookViewModel.ISBN;
            bookDb.ImageUrl = bookViewModel.ImageUrl;
            bookDb.Genre = bookViewModel.Genre;
            bookDb.PublicationDate = bookViewModel.PublicationDate;

            await _bookRepository.Update(bookDb);
        }

        public async Task<List<BookListViewModel>> GetAllBooks()
        {
            List<Book> bookDb = await _bookRepository.GetAll();
            return bookDb.Select(x => x.ToBookListViewModel()).ToList();
        }

        public async Task<BookDetailsViewModel> GetBookDetails(int id)
        {
            Book bookDb = await _bookRepository.GetById(id);
            return bookDb.ToBookDetailsViewModel();
        }

        public async Task<BookViewModel> GetBookForEditing(int id)
        {
            Book book = await _bookRepository.GetById(id) ?? throw new Exception("Book not found!");

            BookViewModel bookViewModel = book.ToBookViewModel();
            return bookViewModel;
        }
    }
}
