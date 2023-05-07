using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList<Product>();

            return Ok(products);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id) 
        { 
            var product = _context.Products.Find(id);
            if(product == null)    
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created($"/get-by-id?id={product.id}", product);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productDelete = _context.Products.Find(id);
            if (productDelete == null)
                return NotFound();
            _context.Products.Remove(productDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
