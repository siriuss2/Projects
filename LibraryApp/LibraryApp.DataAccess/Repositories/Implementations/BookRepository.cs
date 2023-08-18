using LibraryApp.DataAccess.DataContext;
using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories.Implementations
{
    public class BookRepository : IRepository<Book>
    {
        private LibraryAppDbContext _dbContext;

        public BookRepository(LibraryAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<int> DeleteById(int id)
        {
            Book bookDb = await _dbContext.Books.SingleOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception($"{nameof(Book)} cannot be deleted");

            _dbContext.Books.Remove(bookDb);
            _dbContext.SaveChangesAsync();

            return bookDb.Id;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _dbContext.Books
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _dbContext.Books
                .Include(x=>x.Author)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Book entity)
        {
            _dbContext.Books.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
