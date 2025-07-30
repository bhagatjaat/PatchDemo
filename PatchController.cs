using Microsoft.AspNetCore.Mvc;
using PatchManagementApi.Data;
using PatchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PatchManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatchController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PatchController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patch>>> GetPatches()
            => await _context.Patches.ToListAsync();

        [HttpPost]
        public async Task<IActionResult> CreatePatch(Patch patch)
        {
            _context.Patches.Add(patch);
            await _context.SaveChangesAsync();
            return Ok(patch);
        }
    }
}
