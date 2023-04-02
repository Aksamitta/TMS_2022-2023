using Lab28_Aksana.Patrubeika_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab28_Aksana.Patrubeika_WebAPI.Data
{
    public class ApiTestContext : DbContext
    {
        public ApiTestContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
