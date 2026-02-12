using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

// 1) Create Serilog logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

// 2) Setup DI
var services = new ServiceCollection();

services.AddLogging(builder =>
{
    builder.ClearProviders();                 // important: avoid duplicate providers
    builder.AddSerilog(Log.Logger, dispose: true);
    builder.SetMinimumLevel(LogLevel.Debug);
});

services.AddScoped<UserService>();

using var serviceProvider = services.BuildServiceProvider();

// 3) Resolve and run
var userService = serviceProvider.GetRequiredService<UserService>();
userService.CreateUser("John");

// Optional clean flush (useful in some cases)
Log.CloseAndFlush();

public class UserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        _logger.LogInformation("Creating user: {Name}", name);

        try
        {
            _logger.LogInformation("User {Name} created successfully", name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user: {Name}", name);
        }
    }
}
