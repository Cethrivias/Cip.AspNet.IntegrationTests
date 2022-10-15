using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Hello;

public class GetHelloTests : BaseTest, IClassFixture<AppFixture>
{
    public GetHelloTests(AppFixture appFixture) : base(appFixture)
    {
    }

    [Fact]
    public async Task GetHello_ReturnCorrectBody()
    {
        var response = await Client.GetStringAsync("/");

        Assert.Equal("Hello World!", response);
    }

    [Fact]
    public async Task GetHello_ReturnsCorrectStatus()
    {
        var response = await Client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}