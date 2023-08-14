using LibraryApp.DataAccess.DataContext;
using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories.Implementations
{
    public class MemberRepository : IRepository<Member>
    {
        private LibraryAppDbContext _dbContext;
        public MemberRepository(LibraryAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<int> DeleteById(int id)
        {
            Member memberDb = await _dbContext.Members.SingleOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception($"{nameof(Member)} cannot be deleted");

            _dbContext.Members.Remove(memberDb);
            _dbContext.SaveChangesAsync();

            return memberDb.Id;
        }

        public async Task<List<Member>> GetAll()
        {
            return await _dbContext.Members.ToListAsync();
        }

        public async Task<Member> GetById(int id)
        {
            return await _dbContext.Members.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Member entity)
        {
            await _dbContext.Members.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Member entity)
        {
            _dbContext.Members.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
