using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Customers Get");
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("Customers Post");
    }
}