using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Api.IntegrationTests;

public class IntegrationTest1 : IClassFixture<AppFixture>
{
    private readonly HttpClient _client;
    
    public IntegrationTest1(AppFixture appFixture)
    {
        _client = appFixture.App.CreateClient();
    }
    
    [Fact]
    public async Task GetHello_ReturnCorrectBody()
    {
        var response = await _client.GetStringAsync("/");
        
        Assert.Equal("Hello World!", response);
    }
    
    [Fact]
    public async Task GetHello_ReturnsCorrectStatus()
    {
        var response = await _client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}