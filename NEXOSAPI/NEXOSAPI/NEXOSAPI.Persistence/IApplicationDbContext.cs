using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Domain.Entities;
using System.Threading.Tasks;

namespace NEXOSAPI.Persistence
{
    public interface IApplicationDbContext
    {

        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<MaximumBooks> MaximumBooks { get; set; }

        Task<int> SaveChangesAsync();
    }
}
