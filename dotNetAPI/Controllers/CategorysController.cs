using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategorysController : ControllerBase
    {
        private readonly DotNetApiContext _context;
        public CategorysController(DotNetApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList<Category>();

            return Ok(categories);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var categories = _context.Categories.Find(id);
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(Category categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
            return Created($"/get-by-id?id={categories.Id}", categories);
        }
        [HttpPut]
        public IActionResult Update(Category categories)
        {
            _context.Categories.Update(categories);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryDelete = _context.Categories.Find(id);
            if (categoryDelete == null)
                return NotFound();
            _context.Categories.Remove(categoryDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
