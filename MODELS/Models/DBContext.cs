using MODELS.Models;
using Microsoft.EntityFrameworkCore;
using Project;

namespace MODELS.Models
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Costumer> Costumer { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-L1QQEC3\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;MultipleActiveResultSets=True",
                    b => b.MigrationsAssembly("MODELS"));
            }
        }


    }
}