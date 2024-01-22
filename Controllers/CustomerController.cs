using Laconics_Task.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Laconics_Task.Model; // Replace with your actual namespace for repository interfaces


namespace Laconics_Task.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            _repository.Add(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _repository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        /*  // PUT: api/customers/{id}
          [HttpPut("{id}")]
          public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
          {
              if (id != customer.Id)
              {
                  return BadRequest();
              }

              var existingCustomer = _repository.Get(id);
              if (existingCustomer == null)
              {
                  return NotFound();
              }

              _repository.Update(customer);
              return NoContent();
          }*/
        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the request body.");
            }

            var existingCustomer = _repository.Get(id);
            if (existingCustomer == null)
            {
                return NotFound("Customer not found.");
            }

            // Optionally, you can use automapper or manually update only the necessary properties
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.Email = updatedCustomer.Email;

            _repository.Update(existingCustomer);

            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _repository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> ListAllCustomers()
        {
            return Ok(_repository.ListAll());
        }
    }
}