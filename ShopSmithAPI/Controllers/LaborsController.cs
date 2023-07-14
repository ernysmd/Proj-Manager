using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Data;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborsController : ControllerBase
    {
        private readonly ShopContext _context;
        public LaborsController (ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLabors()
        {
            return Ok(await _context.Labors.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetLabor(Guid Id)
        {
            var labors = await _context.Labors.FindAsync(Id);
            if(labors == null)
            {
                return NotFound("Labor was not found.");
            }
            return Ok(labors);
        }

        [HttpPost]
        public async Task<ActionResult<Labor>> PostLabor(Labor labor)
        {
            _context.Labors.Add(labor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Labor), labor);
        }

    }
}
