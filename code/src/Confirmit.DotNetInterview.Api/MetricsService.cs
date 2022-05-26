//==== DO NOT MODIFY THIS FILE ====
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Prometheus;

namespace Confirmit.DotNetInterview.Api
{
    public class MetricsService : BackgroundService
    {
        private readonly ILogger<MetricsService> _logger;
        private readonly MetricsSettings _metricsSettings;

        public MetricsService(ILogger<MetricsService> logger, IOptions<MetricsSettings> metricsSettings)
        {
            _logger = logger;
            _metricsSettings = metricsSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!_metricsSettings.Enabled)
            {
                _logger.LogInformation("Metrics is disabled");
                return;
            }
            _logger.LogInformation("MetricsService is starting...");
            cancellationToken.Register(() => _logger.LogInformation("MetricsService is stopping..."));
            var server = new KestrelMetricServer(_metricsSettings.Port);
            try
            {
                server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error: {0}", e.Message);
                _logger.LogError(e, "Failed to start MetricsService");
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(new TimeSpan(0, 0, 30), cancellationToken);
            }
            await server.StopAsync();
        }
    }
}