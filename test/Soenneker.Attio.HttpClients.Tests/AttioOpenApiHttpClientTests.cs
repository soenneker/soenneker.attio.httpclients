using Soenneker.Attio.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Attio.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AttioOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IAttioOpenApiHttpClient _httpclient;

    public AttioOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IAttioOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
