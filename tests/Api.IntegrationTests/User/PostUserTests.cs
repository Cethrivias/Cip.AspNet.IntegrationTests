using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Api.Requests;
using Moq;
using Xunit;

namespace Api.IntegrationTests.User;

public class PostUserTests : BaseTest, IClassFixture<AppFixture>
{
    public PostUserTests(AppFixture appFixture) : base(appFixture)
    {
    }

    [Fact]
    public async Task PostUser_Return200Status()
    {
        var request = new PostUserRequest("Nick", 123);

        var response = await Client.PostAsJsonAsync("/user", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        SmsServiceMock.Verify(
            it => it.Send(request.Number, $"Welcome, {request.FirstName}"),
            Times.Once
        );
    }

    [Fact]
    public async Task PostUser_Return200StatusDouble()
    {
        var request = new PostUserRequest("Nick", 123);

        var response = await Client.PostAsJsonAsync("/user", request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        SmsServiceMock.Verify(
            it => it.Send(request.Number, $"Welcome, {request.FirstName}"),
            Times.Once
        );
    }
}