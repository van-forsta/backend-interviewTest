using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Refit;
using System;
using System.IO;
using System.Net.Http;

namespace Confirmit.DotNetInterview.Api.xIntegrationTests.Fixtures
{
    /// <summary>
    /// Fixture for testing API endpoints against an in-memory web service when running on a blade
    /// When running outside of a development context, tests will run against the deployed service
    /// </summary>
    public class InMemoryServiceFixture : IDisposable
    {
        protected IServer InMemoryTestServer { get; private set; }
        protected HttpClient InMemoryHttpClient { get; private set; }

        public void Dispose()
        {
            InMemoryTestServer?.Dispose();
        }

        /// <summary>
        /// Resets the in-memory test server
        /// </summary>
        public void ResetTestServer()
        {
            if (UseInMemoryTestServer)
            {
                InMemoryTestServer?.Dispose();
                InMemoryTestServer = CreateTestServer();
                InMemoryHttpClient = CreateTestClient();
            }
        }

        public TInterface GetRestClient<TInterface>() => RestService.For<TInterface>(InMemoryHttpClient);

        protected virtual bool UseInMemoryTestServer => true;

        private IServer CreateTestServer()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile("appsettings.Development.json", optional: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((loggingBuilder) =>
                {
                    loggingBuilder.AddConfiguration();
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                })
                .UseStartup<Startup>();

            return new TestServer(builder);
        }

        private HttpClient CreateTestClient() => ((TestServer)InMemoryTestServer).CreateClient();
    }
}
