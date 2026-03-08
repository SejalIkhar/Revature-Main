         // if your service is in same project namespace
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Add Controllers
builder.Services.AddControllers();

// 🔹 2. Register Customer Service in Dependency Injection
builder.Services.AddScoped<ICustomerService, CustomerService>();

// 🔹 3. Build the app
var app = builder.Build();

// 🔹 4. Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// 🔹 5. Map Controller Endpoints
app.MapControllers();

// 🔹 6. Run Application
app.Run();