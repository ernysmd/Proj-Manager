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
    public class EmployeesController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        // Constructor injection of dependencies (Dependency Inversion Principle)
        public EmployeesController(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            // Single Responsibility Principle: The method is responsible for retrieving all employees.
            // It doesn't handle mapping or database operations directly.
            var employees = await _context.Employees.ToListAsync();
            var employeeDto = employees.Select(e => _mapper.Map<EmployeeDto>(e)).ToList();
            return Ok(employeeDto);
        }

        // GET: api/Employees/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetEmployee(Guid Id)
        {
            // Single Responsibility Principle: The method is responsible for retrieving a single employee by ID.
            // It doesn't handle mapping or null checking directly.
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
            {
                return NotFound("Employee was not found.");
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(Employee employee)
        {
            // Single Responsibility Principle: The method is responsible for adding a new employee to the database.
            // It doesn't handle mapping or complex business logic directly.
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] EmployeeDto dto)
        {
            // Single Responsibility Principle: The method is responsible for updating an existing employee in the database.
            // It doesn't handle mapping or complex business logic directly.
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, employee);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Single Responsibility Principle: The method is responsible for deleting an employee from the database.
            // It doesn't handle complex business logic directly.
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound("Could not find employee ID");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}

