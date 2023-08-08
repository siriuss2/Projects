using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using LibraryApp.Mappers;
using LibraryApp.Services.Interfaces;
using LibraryApp.ViewModels.AuthorViewModels;

namespace LibraryApp.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> _authorRepository)
        {
            this._authorRepository = _authorRepository;
        }

        public Task AddAuthor(AuthorViewModel authorViewModel)
        {
            return _authorRepository.Insert(authorViewModel.ToAuthor());
        }

        public async Task<int> DeleteAuthorById(int id)
        {
            return await _authorRepository.DeleteById(id);
        }

        public async Task EditAuthor(AuthorViewModel authorViewModel)
        {
            Author authorDb = await _authorRepository.GetById(authorViewModel.Id) ?? throw new Exception("Author not found");

            authorDb.Id = authorViewModel.Id;
            authorDb.FirstName = authorViewModel.FirstName;
            authorDb.LastName = authorViewModel.LastName;
            authorDb.Nationality = authorViewModel.Nationality;
            authorDb.ImageUrl = authorViewModel.ImageUrl;
            authorDb.Biography = authorViewModel.Biography;
            authorDb.BirthDate = authorViewModel.BirthDate;
            authorDb.BooksPublished = authorViewModel.BooksPublished;

            await _authorRepository.Update(authorDb);
        }

        public async Task<List<AuthorListViewModel>> GetAllAuthors()
        {
            List<Author> authorDb = await _authorRepository.GetAll();
            return authorDb.Select(x => x.ToAuthorListViewModel()).ToList();
        }

        public async Task<AuthorDetailsViewModel> GetAuthorDetails(int id)
        {
            Author authorDb = await _authorRepository.GetById(id);
            return authorDb.ToAuthorDetailsViewModel();
        }

        public async Task<AuthorViewModel> GetAuthorForEditing(int id)
        {
            Author author = await _authorRepository.GetById(id) ?? throw new Exception("Author not found!");
            AuthorViewModel authorViewModel = author.ToAuthorViewModel();

            return authorViewModel;
        }

        public async Task<List<AuthorForDropdownViewModel>> GetAuthorsForDropdown()
        {
            List<Author> authorDb = await _authorRepository.GetAll();
            return authorDb.Select(x => x.ToAuthorForDropdownViewModel()).ToList();
        }
    }
}
