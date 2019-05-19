using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NuclearReactor.Core.Contracts;
using NuclearReactor.WebApi.Hubs;

namespace NuclearReactor.WebApi.HostedServices
{
    public class ControlTimerService : IHostedService, IDisposable
    {
        private readonly IControlUnit _controlUnit;
        private readonly IPressureContainer _pressureContainer;
        private readonly IPressureSensor _pressureSensor;
        private readonly IHubContext<ReactorHub> _reactorHub;
        private readonly ILogger<ControlTimerService> _logger;
        private Timer _timer;

        public ControlTimerService(
            IControlUnit controlUnit, 
            IPressureContainer pressureContainer,
            IPressureSensor pressureSensor,
            IHubContext<ReactorHub> reactorHub,
            ILogger<ControlTimerService> logger)
        {
            _controlUnit = controlUnit;
            _pressureContainer = pressureContainer;
            _pressureSensor = pressureSensor;
            _reactorHub = reactorHub;
            _logger = logger;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Control Timer Service is starting.");

            _timer = new Timer(DoWork, null, 0, 1000);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _controlUnit.InitiateControl();
            _pressureContainer.UpdatePressure();
            var pressure = _pressureSensor.GetValue();
            _reactorHub.Clients.All.SendAsync("pressureUpdate", pressure);
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