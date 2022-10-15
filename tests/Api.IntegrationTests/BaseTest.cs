using System.Net.Http;
using Api.Services;
using Moq;

namespace Api.IntegrationTests;

public class BaseTest
{
    protected readonly HttpClient Client;
    protected readonly Mock<ISmsService> SmsServiceMock;

    public BaseTest(AppFixture appFixture)
    {
        Client = appFixture.App.CreateClient();
        SmsServiceMock = appFixture.SmsServiceMock;
        SmsServiceMock.Invocations.Clear();

        // Reset your mocks here
    }
}