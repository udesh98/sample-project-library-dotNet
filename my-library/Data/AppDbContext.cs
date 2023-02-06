using Microsoft.EntityFrameworkCore;
using my_library.Data.Models;

namespace my_library.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
