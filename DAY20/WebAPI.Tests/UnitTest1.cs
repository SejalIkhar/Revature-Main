// Import AutoMapper interface used in controller dependency
using AutoMapper;

// Import DataAccessLayer classes like Customer, ICustomerService, DTOs
using DataAccessLayer;

// FakeItEasy library is used to create fake/mock objects for testing
using FakeItEasy;

// FluentValidation is used because controller requires IValidator dependency
using FluentValidation;

// Needed for IActionResult, OkObjectResult used in assertions
using Microsoft.AspNetCore.Mvc;

// Namespace for test project
namespace WebAPI.Tests;

// Test class
public class UnitTest1
{
    // [Fact] attribute tells xUnit this is a test method
    [Fact]

    // Test method name describing expected behaviour
    public void Get_Returns_Ok_With_Mapped_Customers()
    {
        // ===============================
        // Arrange Section
        // Prepare fake dependencies & data
        // ===============================

        // Create fake implementation of ICustomerService
        // Instead of calling real database/service
        var fakeService = A.Fake<ICustomerService>();

        // Create fake AutoMapper instance
        var fakeMapper = A.Fake<IMapper>();

        // Create fake FluentValidation validator
        var fakeValidator = A.Fake<IValidator<CreateCustomerDTO>>();

        // Sample customer list that fake service should return
        var customers = new List<Customer>
        {
            new Customer 
            { 
                Id = 3, 
                Name = "Sarah Smith", 
                Email = "sarah.smith@example.com" 
            }
        };

        // Expected DTO result after AutoMapper mapping
        var customerDtos = new List<CustomerDTO>
        {
            new CustomerDTO 
            { 
                FullName = "Sarah Smith" 
            }
        };

        // Configure fake service behaviour
        // When GetAllCustomers() is called → return customers list
        A.CallTo(() => fakeService.GetAllCustomers()).Returns(customers);

        // Configure fake mapper behaviour
        // When mapper.Map<List<CustomerDTO>>(customers) is called → return DTO list
        A.CallTo(() => fakeMapper.Map<List<CustomerDTO>>(customers)).Returns(customerDtos);

        // Create instance of controller with fake dependencies
        // Dependency Injection is simulated here manually
        var controller = new CustomerController(fakeService, fakeMapper, fakeValidator);

        // ===============================
        // Act Section
        // Execute the method being tested
        // ===============================

        // Call the controller GET method
        var result = controller.Get();

        // ===============================
        // Assert Section
        // Verify that result is correct
        // ===============================

        // Verify the response type is OkObjectResult (HTTP 200)
        var ok = Assert.IsType<OkObjectResult>(result);

        // Verify the returned data is List<CustomerDTO>
        var value = Assert.IsType<List<CustomerDTO>>(ok.Value);

        // Verify that exactly one customer is returned
        Assert.Single(value);

        // Verify that the mapped name is correct
        Assert.Equal("Sarah Smith", value[0].FullName);
    }
}