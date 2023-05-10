using dotNetAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly DotNetApiContext _context;
        public UsersController(DotNetApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _context.Users.ToList<User>();

            return Ok(users);
        }
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var users = _context.Users.Find(id);
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create(User users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();
            return Created($"/get-by-id?id={users.Id}", users);
        }
        [HttpPut]
        public IActionResult Update(User users)
        {
            _context.Users.Update(users);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var userDelete = _context.Users.Find(id);
            if (userDelete == null)
                return NotFound();
            _context.Users.Remove(userDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
