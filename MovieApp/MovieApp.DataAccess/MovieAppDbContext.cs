namespace MovieApp.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using MovieApp.Domain.Domain;

    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .HasMaxLength(50);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
               .HasIndex(x => x.Username)
               .IsUnique();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .HasMany(x => x.MovieUser)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MovieUser)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

        }
    }
}
