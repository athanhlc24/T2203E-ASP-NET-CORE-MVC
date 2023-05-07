using Microsoft.EntityFrameworkCore;

namespace dotNetAPI.Entities
{
    public class DataContext : DbContext// kế thừa DbContext có sẵn
    {
        public DataContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
