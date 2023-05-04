using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T2203E_ASP.NET_CORE_MVC.Entities;
namespace T2203E_ASP.NET_CORE_MVC.Controllers
{
    public class Product1Controller : Controller
    {
        private readonly DataContext _context;
        public Product1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: ProductController1
        public async Task<IActionResult> Index()
        {
            List<Product> list = _context.Products.ToList<Product>();
            return View();
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
