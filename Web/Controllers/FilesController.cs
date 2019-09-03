using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public FilesController(
            ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/Files/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var file =
                await _ctx.Files
                          .FirstOrDefaultAsync(
                               f => f.Id == id);

            if (file is null) return NotFound();

            return File(file.Content,
                "application/octet-stream",
                file.FileName);
        }
    }
}