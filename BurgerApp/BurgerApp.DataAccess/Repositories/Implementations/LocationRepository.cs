using BurgerApp.DataAccess.DataContext;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Repositories.Implementations
{
    public class LocationRepository : IRepository<Location>
    {
        private BurgerAppDbContext _dbContext;

        public LocationRepository(BurgerAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<int> DeleteById(int id)
        {
            Location locationDb = await _dbContext.Locations.SingleOrDefaultAsync(x => x.Id == id);
            if (locationDb == null)
                throw new Exception($"Location with Id:{id} not found!");

            _dbContext.Locations.Remove(locationDb);
            _dbContext.SaveChangesAsync();

            return locationDb.Id;
        }

        public async Task<List<Location>> GetAll()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location> GetById(int id)
        {
            return await _dbContext.Locations.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Location entity)
        {
            await _dbContext.Locations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Location entity)
        {
            _dbContext.Locations.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
