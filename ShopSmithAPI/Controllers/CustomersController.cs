using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Data;
using ShopSmithAPI.Dto;
using ShopSmithAPI.Models;
using System.Data;
using System.Linq;

namespace ShopSmithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        // Constructor injection of dependencies (Dependency Inversion Principle)
        public CustomersController(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            // Single Responsibility Principle: The method is responsible for retrieving all customers.
            // It doesn't handle mapping or database operations directly.
            var customers = await _context.Customers.ToListAsync();
            var customersDtos = customers.Select(c => _mapper.Map<CustomerDto>(c)).ToList();
            return Ok(customersDtos);
        }

        // GET: api/Customers/{Id}
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetCustomer(Guid Id)
        {
            // Single Responsibility Principle: The method is responsible for retrieving a single customer by ID.
            // It doesn't handle mapping or null checking directly.
            var customer = await _context.Customers.FindAsync(Id);
            if (customer == null)
            {
                return NotFound("Customer was not found.");
            }
            var customerDtos = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDtos);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddCustomer(Customer customer)
        {
            // Single Responsibility Principle: The method is responsible for adding a new customer to the database.
            // It doesn't handle mapping or complex business logic directly.
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return Ok(customerDto);
        }

        // PUT: api/Customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] CustomerDto dto)
        {
            // Single Responsibility Principle: The method is responsible for updating an existing customer in the database.
            // It doesn't handle mapping or complex business logic directly.
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, customer);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Customers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Single Responsibility Principle: The method is responsible for deleting a customer from the database.
            // It doesn't handle complex business logic directly.
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound("Could not find customer ID");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}

