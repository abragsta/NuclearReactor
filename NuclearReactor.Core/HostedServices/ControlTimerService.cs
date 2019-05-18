using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NuclearReactor.Core.Contracts;

namespace NuclearReactor.Core.HostedServices
{
    public class ControlTimerService : IHostedService, IDisposable
    {
        private readonly IControlUnit _controlUnit;
        private readonly ILogger<ControlTimerService> _logger;
        private Timer _timer;

        public ControlTimerService(IControlUnit controlUnit, ILogger<ControlTimerService> logger)
        {
            _controlUnit = controlUnit;
            _logger = logger;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Control Timer Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _controlUnit.InitiateControl();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Control Timer Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}