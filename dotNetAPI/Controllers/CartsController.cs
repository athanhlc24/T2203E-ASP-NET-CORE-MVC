using dotNetAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartsController : ControllerBase
    {
        private readonly DotNetApiContext _context;
        public CartsController(DotNetApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var carts = _context.Carts.ToList<Cart>();

            return Ok(carts);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var carts = _context.Carts.Find(id);
            if (carts == null)
                return NotFound();
            return Ok(carts);
        }

        [HttpPost]
        public IActionResult Create(Cart carts)
        {
            _context.Carts.Add(carts);
            _context.SaveChanges();
            return Created($"/get-by-id?id={carts.Id}", carts);
        }
        [HttpPut]
        public IActionResult Update(Cart carts)
        {
            _context.Carts.Update(carts);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cartDelete = _context.Carts.Find(id);
            if (cartDelete == null)
                return NotFound();
            _context.Carts.Remove(cartDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
