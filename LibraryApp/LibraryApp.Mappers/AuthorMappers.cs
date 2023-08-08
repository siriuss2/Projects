using LibraryApp.Domain.Models;
using LibraryApp.ViewModels.AuthorViewModels;

namespace LibraryApp.Mappers
{
    public static class AuthorMappers
    {
        public static AuthorListViewModel ToAuthorListViewModel(this Author author)
        {
            return new AuthorListViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality,
                ImageUrl = author.ImageUrl
            };
        }

        public static AuthorDetailsViewModel ToAuthorDetailsViewModel(this Author author)
        {
            return new AuthorDetailsViewModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality,
                ImageUrl = author.ImageUrl,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                BooksPublished = author.BooksPublished
            };
        }

        public static Author ToAuthor(this AuthorViewModel authorViewModel)
        {
            return new Author
            {
                Id = authorViewModel.Id,
                FirstName = authorViewModel.FirstName,
                LastName = authorViewModel.LastName,
                Nationality = authorViewModel.Nationality,
                ImageUrl = authorViewModel.ImageUrl,
                Biography = authorViewModel.Biography,
                BirthDate = authorViewModel.BirthDate,
                BooksPublished = authorViewModel.BooksPublished
            };
        }

        public static AuthorViewModel ToAuthorViewModel(this Author author)
        {
            return new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality,
                ImageUrl = author.ImageUrl,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                BooksPublished = author.BooksPublished
            };
        }

        public static AuthorForDropdownViewModel ToAuthorForDropdownViewModel(this Author author)
        {
            return new AuthorForDropdownViewModel
            {
                Id = author.Id,
                FullName = author.FirstName + " " + author.LastName
            };
        }
    }
}
