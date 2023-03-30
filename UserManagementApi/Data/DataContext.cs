using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserImages> UserImages { get; set; }
    }
}
