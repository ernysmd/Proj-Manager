using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Data;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ShopContext _context;
        public VehiclesController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllVehicles()
        {
            return Ok (await _context.Vehicles.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetVehicle(Guid Id)
        {
            var vehicle = await _context.Vehicles.FindAsync(Id);
            if(vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetVehicle",
                new { id = vehicle.Id },
                vehicle);
        }
    }
}
