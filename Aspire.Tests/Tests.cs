using Xunit.Abstractions;

namespace Aspire.Tests;

public class Tests
{
    [Fact]
    public async Task Test1()
    {
        var builder = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Aspire>();
        var app = await builder.BuildAsync();
        await app.StartAsync();
    }
}