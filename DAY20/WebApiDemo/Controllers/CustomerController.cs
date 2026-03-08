// Import AutoMapper for object mapping
using AutoMapper;

// Import classes from DataAccessLayer such as Customer, DTOs, Services
using DataAccessLayer;

// Import FluentValidation for validating input data
using FluentValidation;

// Import ASP.NET MVC features like ControllerBase and IActionResult
using Microsoft.AspNetCore.Mvc;


// ApiController attribute enables automatic model validation and API features
[ApiController]

// Defines the base route for this controller
// Example: api/v1/customer
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    // Dependency: Customer Service used to access customer data
    ICustomerService customerService;

    // Dependency: AutoMapper used for mapping entities to DTOs
    IMapper mapper;

    // Dependency: FluentValidation validator for CreateCustomerDTO
    IValidator<CreateCustomerDTO> createCustomerDTOValidator;


    // Constructor Injection
    // ASP.NET Core automatically injects dependencies from the DI container
    public CustomerController(
        ICustomerService customerService,
        IMapper mapper,
        IValidator<CreateCustomerDTO> createCustomerDTOValidator)
    {
        // Assign injected dependencies to local variables
        this.customerService = customerService;
        this.mapper = mapper;
        this.createCustomerDTOValidator = createCustomerDTOValidator;
    }


    // ===============================
    // GET METHOD
    // Endpoint: GET api/v1/customer
    // ===============================
    [HttpGet]
    public IActionResult Get()
    {
        // Call service layer to fetch all customers
        var customers = customerService.GetAllCustomers();


        // Previously manual mapping was done like this:
        // var customerDTOs = customers.Select(c => new CustomerDTO
        // {
        //     FullName = c.Name
        // }).ToList();
        //
        // This violates DRY and Single Responsibility Principle
        // because controller should not handle mapping logic


        // AutoMapper automatically converts Customer → CustomerDTO
        var customerDTOs = mapper.Map<List<CustomerDTO>>(customers);


        // Return HTTP 200 response with mapped DTO data
        return Ok(customerDTOs);
    }


    // ===============================
    // POST METHOD
    // Endpoint: POST api/v1/customer
    // ===============================
    [HttpPost]
    public IActionResult Post(CreateCustomerDTO createCustomerDTO)
    {
        // Validate incoming request using FluentValidation
        var validationResult = createCustomerDTOValidator.Validate(createCustomerDTO);

        // If validation fails return HTTP 400 (Bad Request)
        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors);
        }


        // If validation passes normally we would:
        // 1️⃣ Map DTO → Customer entity
        // 2️⃣ Save to database
        // 3️⃣ Return created response


        // For now we just return the received data
        return Ok(createCustomerDTO);
    }
}