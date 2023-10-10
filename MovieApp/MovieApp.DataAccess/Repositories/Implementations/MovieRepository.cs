namespace MovieApp.DataAccess.Repositories.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using MovieApp.DataAccess.Repositories.Interfaces;
    using MovieApp.Domain.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppDbContext _dbContext;

        public MovieRepository(MovieAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }
        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateAsync(Movie entity)
        {
            await _dbContext.Movies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Movie entity)
        {
            _dbContext.Movies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Movie movieDb = await _dbContext.Movies.SingleOrDefaultAsync(x => x.Id == id);

            if(movieDb == null)
                throw new Exception($"Movie with Id:{id} not found!");

            _dbContext.Movies.Remove(movieDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
