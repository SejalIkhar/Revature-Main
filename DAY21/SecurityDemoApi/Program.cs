using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ✅ CORS policy (allow frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // your frontend origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ✅ JWT Authentication (validation)
var jwt = builder.Configuration.GetSection("Jwt");
var keyBytes = Encoding.UTF8.GetBytes(jwt["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ClockSkew = TimeSpan.Zero
    };
});

// ✅ Authorization Policies (Policy-based + Claims-based)
builder.Services.AddAuthorization(options =>
{
    // Role-based policy
    options.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));

    // Claims-based policy: Department must be HR
    options.AddPolicy("HRDepartment", p => p.RequireClaim("Department", "HR"));

    // Combined policy: Admin AND HR
    options.AddPolicy("AdminHR", p => p.RequireRole("Admin")
                                      .RequireClaim("Department", "HR"));
});

var app = builder.Build();

app.UseHttpsRedirection();

// ✅ Order matters
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Needed for integration tests
public partial class Program { }