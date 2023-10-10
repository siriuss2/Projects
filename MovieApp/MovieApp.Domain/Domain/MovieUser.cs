namespace MovieApp.Domain.Domain
{
    public class MovieUser : BaseEntity
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
