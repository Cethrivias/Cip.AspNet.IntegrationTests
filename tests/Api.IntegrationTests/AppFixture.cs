using System;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Api.IntegrationTests;

public class AppFixture : IAsyncDisposable
{
    public WebApplicationFactory<Program> App { get; private init; }
    public Mock<ISmsService> SmsServiceMock { get; } = new Mock<ISmsService>();

    public AppFixture()
    {
        App = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                    services.AddSingleton<ISmsService>(_ => SmsServiceMock.Object)
                )
            );
    }

    public ValueTask DisposeAsync()
    {
        return App.DisposeAsync();
    }
}