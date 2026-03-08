using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;
using DataAccessLayer;
//using WebApiDemo.Controllers;
using System.Collections.Generic;

namespace WebAPI.Tests;

public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    // Test GET all customers
    [Fact]
    public async Task Get_Customers()
    {
        var response = await _client.GetAsync("/api/v1/customer");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
        Assert.NotNull(customers);
    }

    // Test GET customer by ID
    [Fact]
    public async Task Get_CustomerById()
    {
        int testId = 1; // change to an existing ID in your database or seed data
        var response = await _client.GetAsync($"/api/v1/customer/{testId}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
        Assert.NotNull(customers);
    }

    // Test POST customer
    [Fact]
    public async Task Post_Customers()
    {
        var customer = new
        {
            Name = "Johnathan Doe",   // Must be >= 10 characters due to validator
            Email = "john@example.com",
            Age = 30
        };

        var response = await _client.PostAsJsonAsync("/api/v1/customer", customer);

        // Print response content for debugging if needed
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Verify returned DTO matches request
        var returnedCustomer = await response.Content.ReadFromJsonAsync<CreateCustomerDTO>();
        Assert.Equal(customer.Name, returnedCustomer.Name);
        Assert.Equal(customer.Email, returnedCustomer.Email);
        Assert.Equal(customer.Age, returnedCustomer.Age);
    }
}