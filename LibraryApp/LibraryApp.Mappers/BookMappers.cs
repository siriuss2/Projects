using LibraryApp.Domain.Models;
using LibraryApp.ViewModels.BookViewModels;

namespace LibraryApp.Mappers
{
    public static class BookMappers
    {
        public static BookListViewModel ToBookListViewModel(this Book book)
        {
            return new BookListViewModel
            {
                Id = book.Id,
                ImageUrl = book.ImageUrl,
                PublicationDate = book.PublicationDate,
                Synopsis = book.Synopsis,
                Title = book.Title
            };
        }

        public static BookDetailsViewModel ToBookDetailsViewModel(this Book book)
        {
            if (book.Author == null)
                book.Author = new Author();

            return new BookDetailsViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Synopsis = book.Synopsis,
                AuthorFullName = $"{book.Author.FirstName} {book.Author.LastName}",
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate
            };
        }

        public static Book ToBook(this BookViewModel bookViewModel)
        {
            return new Book
            {
                Id = bookViewModel.Id,
                Title = bookViewModel.Title,
                Genre = bookViewModel.Genre,
                ImageUrl = bookViewModel.ImageUrl,
                ISBN = bookViewModel.ISBN,
                PublicationDate = bookViewModel.PublicationDate,
                Synopsis = bookViewModel.Synopsis,
                AuthorId = bookViewModel.AuthorId
            };
        }

        public static BookViewModel ToBookViewModel(this Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                Synopsis = book.Synopsis,
                AuthorId = book.AuthorId
            };
        }
    }
}
