using Microsoft.AspNetCore.Mvc;
using T2203E_ASP.NET_CORE_MVC.Entities;

namespace T2203E_ASP.NET_CORE_MVC.Controllers
{
    public class ProductController : Controller
    {
        private DataContext _context;
        public ProductController(DataContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {   
        /*    Product p = new Product()
            {
                Name = "ABC",thumbnail = "abc",Price = 120
            };
            _context.Products.AddAsync(p);
            _context.SaveChangesAsync();*/
            return View();
        }
    }
}
