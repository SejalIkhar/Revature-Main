using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{
    private readonly ILogger<CustomerService> _logger;

    // Simulated in-memory data
    private static List<CustomerDTO> _customers = new List<CustomerDTO>
    {
        new CustomerDTO { Id = 1, Name = "Acme Corp", Email = "contact@acme.com" },
        new CustomerDTO { Id = 2, Name = "TechStart Inc", Email = "info@techstart.com" }
    };

    public CustomerService(ILogger<CustomerService> logger)
    {
        _logger = logger;
    }

    public async Task<List<CustomerDTO>> GetAllCustomersAsync()
    {
        _logger.LogInformation("Fetching all customers");
        return await Task.FromResult(_customers);
    }

    public async Task<CustomerDTO?> GetCustomerByIdAsync(int id)
    {
        _logger.LogInformation($"Fetching customer {id}");
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        return await Task.FromResult(customer);
    }

    public async Task<CustomerDTO> CreateCustomerAsync(CreateCustomerDTO dto)
    {
        var newCustomer = new CustomerDTO
        {
            Id = _customers.Max(c => c.Id) + 1,
            Name = dto.Name,
            Email = dto.Email
        };

        _customers.Add(newCustomer);

        _logger.LogInformation($"Customer created: {newCustomer.Name}");

        return await Task.FromResult(newCustomer);
    }

    public async Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDTO dto)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);

        if (customer == null)
            return await Task.FromResult(false);

        customer.Name = dto.Name;
        customer.Email = dto.Email;

        _logger.LogInformation($"Customer updated: {id}");

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);

        if (customer == null)
            return await Task.FromResult(false);

        _customers.Remove(customer);

        _logger.LogInformation($"Customer deleted: {id}");

        return await Task.FromResult(true);
    }
}