using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SecurityDemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    // ✅ Just authenticated user
    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        var name = User.Identity?.Name;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        var dept = User.FindFirst("Department")?.Value;

        return Ok(new { name, role, department = dept });
    }

    // ✅ Role-based
    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly() => Ok("Hello Admin ✅");

    // ✅ Policy-based (claim requirement)
    [Authorize(Policy = "HRDepartment")]
    [HttpGet("hr")]
    public IActionResult HrOnly() => Ok("Hello HR ✅");

    // ✅ Combined Policy (Admin + HR)
    [Authorize(Policy = "AdminHR")]
    [HttpGet("admin-hr")]
    public IActionResult AdminHrOnly() => Ok("Hello Admin from HR ✅");

    // ✅ Public endpoint
    [AllowAnonymous]
    [HttpGet("public")]
    public IActionResult Public() => Ok("Anyone can access ✅");
}