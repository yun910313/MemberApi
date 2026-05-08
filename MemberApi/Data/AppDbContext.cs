using MemberApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MemberApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasNoKey();

            modelBuilder.Entity<Store>().ToTable("designerdata");

            modelBuilder.Entity<Store>()
                .Property(x => x.StoreName)
                .HasColumnName("服務店家");

            modelBuilder.Entity<Store>()
                .Property(x => x.Address)
                .HasColumnName("服務地址");

            base.OnModelCreating(modelBuilder);
        }
    }
}
