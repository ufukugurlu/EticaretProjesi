using Eticaret.Data.Entities;
using Eticaret.Data.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;


namespace Eticaret.Data.EntityFramework
{
    public class EticaretDBContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=EticaretDb;Integrated Security=True;");
            ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
        }
    }
}


