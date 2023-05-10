using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly DotNetApiContext _context;
        public BrandsController(DotNetApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var brands = _context.Brands.ToList<Brand>();

            return Ok(brands);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var brands = _context.Brands.Find(id);
            if (brands == null)
                return NotFound();
            return Ok(brands);
        }

        [HttpPost]
        public IActionResult Create(Brand brands)
        {
            _context.Brands.Add(brands);
            _context.SaveChanges();
            return Created($"/get-by-id?id={brands.Id}", brands);
        }
        [HttpPut]
        public IActionResult Update(Brand brands)
        {
            _context.Brands.Update(brands);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var brandDelete = _context.Brands.Find(id);
            if (brandDelete == null)
                return NotFound();
            _context.Brands.Remove(brandDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
