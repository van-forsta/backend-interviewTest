using Confirmit.DotNetInterview.Api.xIntegrationTests.Fixtures;
using Xunit.Abstractions;
using Xunit;

namespace Confirmit.DotNetInterview.Api.xIntegrationTests
{
    /// <summary>
    /// Base class for testing against the in-memory web service in a dev environment
    /// </summary>
    public abstract class InMemoryServiceTestBase : IClassFixture<InMemoryServiceFixture>
    {
        protected readonly InMemoryServiceFixture Fixture;

        public InMemoryServiceTestBase(ITestOutputHelper helper, InMemoryServiceFixture fixture)
        {
            Fixture = fixture;
            Fixture.ResetTestServer();
        }

        public TInterface GetRestClient<TInterface>() => Fixture.GetRestClient<TInterface>();
    }
}
