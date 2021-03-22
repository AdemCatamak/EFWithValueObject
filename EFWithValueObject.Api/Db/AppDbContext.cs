using EFWithValueObject.Api.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFWithValueObject.Api.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Order> Orders { get; private set; }
    }
}