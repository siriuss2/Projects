namespace MovieApp.Domain.Domain
{
    using MovieApp.Domain.Enums;
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public MovieGenre Genre { get; set; }
        public List<MovieUser> MovieUser { get; set; } = new List<MovieUser>();
    }
}
