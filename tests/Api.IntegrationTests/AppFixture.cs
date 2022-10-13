using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.IntegrationTests;

public class AppFixture : IAsyncDisposable
{
    public WebApplicationFactory<Program> App { get; private init; }

    public AppFixture()
    {
        App = new WebApplicationFactory<Program>();
    }

    public ValueTask DisposeAsync()
    {
        return App.DisposeAsync();
    }
}