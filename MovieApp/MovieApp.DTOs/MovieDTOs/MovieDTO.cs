namespace MovieApp.DTOs.MovieDTOs
{
    using MovieApp.Domain.Enums;

    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public MovieGenre Genre { get; set; }
    }
}
