using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class EfAppContext : DbContext
    {
        public EfAppContext()
        {

        }
        public EfAppContext(DbContextOptions<EfAppContext> contextOptions) : base(contextOptions/*@"server=(localdb)\MSSQLLocalDB; Database=EfAppCoreDb;integrated security=true"*/)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
