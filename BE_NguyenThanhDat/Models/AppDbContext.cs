using System.Data.Entity;
using BE_NguyenThanhDat.Models;

namespace BE_NguyenThanhDat.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyStoreDB") { }

        public DbSet<Category> Categories { get; set; }
    }
}
