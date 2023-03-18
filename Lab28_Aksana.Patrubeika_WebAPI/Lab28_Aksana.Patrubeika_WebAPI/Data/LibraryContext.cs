using Lab28_Aksana.Patrubeika_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab28_Aksana.Patrubeika_WebAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
