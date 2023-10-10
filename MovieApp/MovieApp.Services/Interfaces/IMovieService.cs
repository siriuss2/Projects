namespace MovieApp.Services.Interfaces
{
    using MovieApp.DTOs.MovieDTOs;

    public interface IMovieService
    {
        Task<List<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task CreateMovieAsync(CreateMovieDTO createMovieDTO);
        Task EditMovieAsync(EditMovieDTO editMovieDTO);
        Task DeleteMovieAsync(int id);

    }
}
