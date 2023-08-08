using LibraryApp.ViewModels.BookViewModels;

namespace LibraryApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookListViewModel>> GetAllBooks();
        Task<BookDetailsViewModel> GetBookDetails(int id);
        Task<int> DeleteBookById(int id);
        Task AddBook(BookViewModel bookViewModel);
        Task<BookViewModel> GetBookForEditing(int id);
        Task EditBook(BookViewModel bookViewModel);
    }
}
