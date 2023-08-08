using LibraryApp.DataAccess.DataContext;
using LibraryApp.DataAccess.Repositories.Implementations;
using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Domain.Models;
using LibraryApp.Services.Implementations;
using LibraryApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<LibraryAppDbContext>(options =>
            options.UseSqlServer(@"Data Source=(localdb)\LibraryApp;Database=LibraryAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Author>, AuthorRepository>();
            services.AddTransient<IRepository<Book>, BookRepository>();
        }
    }
}
