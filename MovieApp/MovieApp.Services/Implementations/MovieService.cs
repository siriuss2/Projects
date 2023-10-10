namespace MovieApp.Services.Implementations
{
    using MovieApp.DataAccess.Repositories.Interfaces;
    using MovieApp.Domain.Domain;
    using MovieApp.DTOs.MovieDTOs;
    using MovieApp.Mappers;
    using MovieApp.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository _movieRepository)
        {
            this._movieRepository = _movieRepository;
        }
        public async Task<List<MovieDTO>> GetAllMoviesAsync()
        {
            List<Movie> movieDb = await _movieRepository.GetAllAsync();

            if(movieDb == null)
                throw new Exception("Contact the support team");

            return movieDb.Select(x=>x.ToMovieDTO()).ToList();
        }
        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            Movie movieDb = await _movieRepository.GetByIdAsync(id);

            if(movieDb == null)
                throw new Exception("Contact the support team");

            return movieDb.ToMovieDTO();

        }
        public async Task CreateMovieAsync(CreateMovieDTO createMovieDTO)
        {
            Movie movieDb = createMovieDTO.ToMovie();
            await _movieRepository.CreateAsync(movieDb);
        }
        public async Task EditMovieAsync(EditMovieDTO editMovieDTO)
        {
            Movie movieDb = await _movieRepository.GetByIdAsync(editMovieDTO.Id);

            if(movieDb == null)
                throw new Exception("The movie can not be found");

            movieDb.Title = editMovieDTO.Title;
            movieDb.Description = editMovieDTO.Description;
            movieDb.Year = editMovieDTO.Year;
            movieDb.Genre = editMovieDTO.Genre;

            await _movieRepository.UpdateAsync(movieDb);
        }
        public async Task DeleteMovieAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
    }
}
