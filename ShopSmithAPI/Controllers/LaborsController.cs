using AutoMapper;
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
    public class LaborsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ShopContext _context;

        // Constructor injection of dependencies (Dependency Inversion Principle)
        public LaborsController(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Labors
        [HttpGet]
        public async Task<ActionResult> GetAllLabors()
        {
            // Single Responsibility Principle: The method is responsible for retrieving all labors.
            // It doesn't handle mapping or database operations directly.
            var labors = await _context.Labors.ToListAsync();
            var laborDto = labors.Select(l => _mapper.Map<Labor>(l)).ToList();

            return Ok(laborDto);
        }

        // GET: api/Labors/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetLabor(Guid Id)
        {
            // Single Responsibility Principle: The method is responsible for retrieving a single labor by ID.
            // It doesn't handle mapping or null checking directly.
            var labors = await _context.Labors.FindAsync(Id);
            if (labors == null)
            {
                return NotFound("Labor was not found.");
            }
            var laborDto = _mapper.Map<Labor>(labors);
            return Ok(laborDto);
        }

        // POST: api/Labors
        [HttpPost]
        public async Task<ActionResult<Labor>> PostLabor(Labor labor)
        {
            // Single Responsibility Principle: The method is responsible for adding a new labor to the database.
            // It doesn't handle mapping or complex business logic directly.
            _context.Labors.Add(labor);
            await _context.SaveChangesAsync();

            var laborDto = _mapper.Map<LaborDto>(labor);

            return Ok(laborDto);
        }

        // PUT: api/Labors/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] LaborDto dto)
        {
            // Single Responsibility Principle: The method is responsible for updating an existing labor in the database.
            // It doesn't handle mapping or complex business logic directly.
            var labor = await _context.Labors.FindAsync(id);
            if (labor == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, labor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Labors/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Single Responsibility Principle: The method is responsible for deleting a labor from the database.
            // It doesn't handle complex business logic directly.
            var labor = await _context.Labors.FindAsync(id);
            if (labor == null)
            {
                return NotFound("Could not find Labor ID");
            }

            _context.Labors.Remove(labor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

