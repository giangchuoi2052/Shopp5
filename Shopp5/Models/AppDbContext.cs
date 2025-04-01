using Microsoft.EntityFrameworkCore;

namespace Shopp5.Models
{
    public class AppDbContext : DbContext
    {
     
            // Constructor cần thiết cho việc sử dụng AddDbContext
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
        

    }
}
