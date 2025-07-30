using Microsoft.AspNetCore.Mvc;
using PatchManagementApi.Data;
using PatchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PatchManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DeviceController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
            => await _context.Devices.ToListAsync();

        [HttpPost]
        public async Task<IActionResult> AddDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return Ok(device);
        }
    }
}
