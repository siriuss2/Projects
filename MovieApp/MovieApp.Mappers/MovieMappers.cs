namespace MovieApp.Mappers
{
    using MovieApp.Domain.Domain;
    using MovieApp.DTOs.MovieDTOs;
    public static class MovieMappers
    {
        public static MovieDTO ToMovieDTO(this Movie movie)
        {
            return new MovieDTO()
            {
                Id = movie.Id,
                Description = movie.Description,
                Genre = movie.Genre,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        public static Movie ToMovie(this CreateMovieDTO createMovieDTO)
        {
            return new Movie()
            {
                Description = createMovieDTO.Description,
                Genre = createMovieDTO.Genre,
                Title = createMovieDTO.Title,
                Year = createMovieDTO.Year
            };
        }
    }
}
