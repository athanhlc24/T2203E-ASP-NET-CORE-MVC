using Microsoft.AspNetCore.Mvc;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("/api/upload")]
    public class UploadsController : ControllerBase
    {

        [HttpPost]
        [Route("image")]
        public IActionResult Index(IFormFile image)
        {
            if(image == null)
            {
                return BadRequest("Vui long gui file dinh kem");
            }
            var path = "wwwroot/Uploads";
            var fileName = Guid.NewGuid().ToString()+Path.GetFileName(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(),path, fileName);
            image.CopyTo(new FileStream(upload, FileMode.Create));
            var rs = $"{Request.Scheme}://{Request.Host}/Uploads/{fileName}";
            return Ok(rs);
        }
    }
}
