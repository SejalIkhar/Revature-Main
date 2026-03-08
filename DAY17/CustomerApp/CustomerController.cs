using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }

    // GET BY ID
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdCustomer = await _service.CreateCustomerAsync(dto);

        return CreatedAtAction(
            nameof(GetCustomerById),
            new { id = createdCustomer.Id },
            createdCustomer
        );
    }

    // PUT
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateCustomerAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var deleted = await _service.DeleteCustomerAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}