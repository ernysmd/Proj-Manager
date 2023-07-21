using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Data;
using ShopSmithAPI.Dto;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ShopContext _context;

        // Constructor injection of dependencies (Dependency Inversion Principle)
        public VehiclesController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult> GetAllVehicles()
        {
            // Single Responsibility Principle: The method is responsible for retrieving all vehicles.
            // It doesn't handle complex business logic, just the data retrieval.
            return Ok(await _context.Vehicles.ToListAsync());
        }

        // GET: api/Vehicles/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetVehicle(Guid Id)
        {
            // Single Responsibility Principle: The method is responsible for retrieving a single vehicle by ID.
            // It doesn't handle mapping or null checking directly.
            var vehicle = await _context.Vehicles.FindAsync(Id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            return Ok(vehicle);
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            // Single Responsibility Principle: The method is responsible for adding a new vehicle to the database.
            // It doesn't handle complex business logic directly.
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return Ok(vehicle);
        }

        // PUT: api/Vehicles/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Vehicle updatedVehicle)
        {
            // Single Responsibility Principle: The method is responsible for updating an existing vehicle in the database.
            // It doesn't handle complex business logic directly.
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            // Update the vehicle entity with the updatedVehicle values
            _context.Entry(vehicle).CurrentValues.SetValues(updatedVehicle);

            await _context.SaveChangesAsync();

            return Ok(updatedVehicle);
        }

        // DELETE: api/Vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Single Responsibility Principle: The method is responsible for deleting a vehicle from the database.
            // It doesn't handle complex business logic directly.
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound("Could not find vehicle ID");
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

