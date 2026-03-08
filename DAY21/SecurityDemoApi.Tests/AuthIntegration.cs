using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;

public class AuthIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PublicEndpoint_ReturnsOk()
    {
        var res = await _client.GetAsync("/api/secure/public");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
    }

    [Fact]
    public async Task ProtectedEndpoint_WithoutToken_Returns401()
    {
        var res = await _client.GetAsync("/api/secure/profile");
        Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
    }

    [Fact]
    public async Task Login_ReturnsToken_And_ProfileWorks()
    {
        var login = new { username = "admin1", password = "123", role = "Admin", department = "HR" };
        var loginRes = await _client.PostAsJsonAsync("/api/auth/login", login);
        loginRes.EnsureSuccessStatusCode();

        var auth = await loginRes.Content.ReadFromJsonAsync<AuthResp>();
        Assert.False(string.IsNullOrWhiteSpace(auth?.Token));

        _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", auth!.Token);

        var profileRes = await _client.GetAsync("/api/secure/profile");
        Assert.Equal(HttpStatusCode.OK, profileRes.StatusCode);
    }

    private class AuthResp
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAtUtc { get; set; }
    }
}