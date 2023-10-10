namespace MovieApp.DataAccess.Repositories.Interfaces
{
    using MovieApp.Domain.Domain;
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsername(string username);
        Task<User> LoginUser(string username, string password);
    }
}
