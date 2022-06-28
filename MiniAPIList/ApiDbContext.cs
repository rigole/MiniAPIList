using Microsoft.EntityFrameworkCore;

namespace MiniAPIList
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Grocery> Groceries => Set<Grocery>();
         public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
