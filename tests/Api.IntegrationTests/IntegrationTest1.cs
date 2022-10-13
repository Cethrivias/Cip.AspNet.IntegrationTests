using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Api.IntegrationTests;

public class IntegrationTest1
{
    [Fact]
    public async Task Test1()
    {
        await using var app = new WebApplicationFactory<Program>();
        using var client = app.CreateClient();
        
        var response = await client.GetStringAsync("/");
        
        Assert.Equal("Hello World!", response);
    }
}