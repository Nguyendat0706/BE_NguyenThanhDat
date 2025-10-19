using System.Data.Entity;
using BE_NguyenThanhDat.Models;

namespace BE_NguyenThanhDat.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyStoreDB") { Database.SetInitializer<AppDbContext>(null); }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
