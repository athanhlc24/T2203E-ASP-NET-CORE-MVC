using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategorysController : ControllerBase
    {
        private readonly DataContext _context;
        public CategorysController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Category.ToList<Category>();

            return Ok(categories);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var categories = _context.Category.Find(id);
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(Category categories)
        {
            _context.Category.Add(categories);
            _context.SaveChanges();
            return Created($"/get-by-id?id={categories.id}", categories);
        }
        [HttpPut]
        public IActionResult Update(Category categories)
        {
            _context.Category.Update(categories);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryDelete = _context.Category.Find(id);
            if (categoryDelete == null)
                return NotFound();
            _context.Category.Remove(categoryDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
