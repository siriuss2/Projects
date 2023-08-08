using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.DataContext
{
    public class LibraryAppDbContext : DbContext
    {
        public LibraryAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.BookReservations)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Member>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Member)
                .HasForeignKey(x => x.MemberId);

            modelBuilder.Entity<Reservation>()
                .HasMany(x => x.BookReservations)
                .WithOne(x => x.Reservation)
                .HasForeignKey(x => x.ReservationId);

        }
    }
}
