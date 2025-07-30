using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatchManagementApi.Data;
using PatchManagementApi.Models;

namespace PatchManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatchStatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatchStatusController(AppDbContext context) => _context = context;

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyPatchToDevice(int patchId, int deviceId)
        {
            var patch = await _context.Patches.FindAsync(patchId);
            var device = await _context.Devices.FindAsync(deviceId);

            if (patch == null || device == null)
                return NotFound("Patch or Device not found");

            var status = new PatchStatus
            {
                PatchId = patchId,
                DeviceId = deviceId,
                IsApplied = true,
                AppliedOn = DateTime.UtcNow
            };

            _context.PatchStatuses.Add(status);
            await _context.SaveChangesAsync();
            return Ok(status);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetPatchStatuses() =>
            Ok(await _context.PatchStatuses
                .Include(p => p.Patch)
                .Include(p => p.Device)
                .ToListAsync());
    }
}
