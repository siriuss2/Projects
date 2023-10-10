namespace MovieApp.DataAccess.Repositories.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using MovieApp.DataAccess.Repositories.Interfaces;
    using MovieApp.Domain.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly MovieAppDbContext _dbContext;

        public UserRepository(MovieAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task<User> LoginUser(string username, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() 
            && x.Password.ToLower() == password.ToLower());
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
