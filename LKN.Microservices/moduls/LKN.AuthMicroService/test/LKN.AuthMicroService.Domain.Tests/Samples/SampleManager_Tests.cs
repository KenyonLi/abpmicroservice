using System.Threading.Tasks;
using Xunit;

namespace LKN.AuthMicroService.Samples;

public class SampleManager_Tests : AuthMicroServiceDomainTestBase
{
    //private readonly SampleManager _sampleManager;

    public SampleManager_Tests()
    {
        //_sampleManager = GetRequiredService<SampleManager>();
    }

    [Fact]
    public Task Method1Async()
    {
        return Task.CompletedTask;
    }
}
