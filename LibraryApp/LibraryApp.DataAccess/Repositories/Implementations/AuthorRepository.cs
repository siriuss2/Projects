using LibraryApp.DataAccess.DataContext;
using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories.Implementations
{
    public class AuthorRepository : IRepository<Author>
    {
        private LibraryAppDbContext _dbContext;

        public AuthorRepository(LibraryAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public async Task<int> DeleteById(int id)
        {
            Author authorDb = await _dbContext.Authors.SingleOrDefaultAsync(x => x.Id == id);
            if (authorDb == null)
                throw new Exception($"Author with Id:{id} is not found");

            _dbContext.Authors.Remove(authorDb);
            _dbContext.SaveChangesAsync();

            return authorDb.Id;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _dbContext.Authors
                .ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await _dbContext.Authors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Author entity)
        {
            await _dbContext.Authors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Author entity)
        {
            _dbContext.Authors.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
