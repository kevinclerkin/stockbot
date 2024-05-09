using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockBotAPI.Models;

namespace StockBotAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

            
        }

        public DbSet<Stock> Stocks { get; set;}

        public DbSet<Portfolio> Portfolios { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(a => new { a.AppUserId, a.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolio)
                .HasForeignKey(a => a.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolio)
                .HasForeignKey(a => a.StockId);

            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
                
                
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
