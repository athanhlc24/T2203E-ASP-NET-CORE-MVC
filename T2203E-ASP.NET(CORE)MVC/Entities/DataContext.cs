using Microsoft.EntityFrameworkCore;
namespace T2203E_ASP.NET_CORE_MVC.Entities;

public class DataContext:DbContext// kế thừa DbContext có sẵn
{
    public DataContext(DbContextOptions<DataContext> options) 
       : base(options) {
    }
    public DbSet<Product> Products { get; set;}

   
}
