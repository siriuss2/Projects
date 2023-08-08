using LibraryApp.ViewModels.AuthorViewModels;

namespace LibraryApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorListViewModel>> GetAllAuthors();
        Task<AuthorDetailsViewModel> GetAuthorDetails(int id);
        Task<int> DeleteAuthorById(int id);
        Task AddAuthor(AuthorViewModel authorViewModel);
        Task<AuthorViewModel> GetAuthorForEditing(int id);
        Task EditAuthor(AuthorViewModel authorViewModel);
        Task<List<AuthorForDropdownViewModel>> GetAuthorsForDropdown();
    }
}
