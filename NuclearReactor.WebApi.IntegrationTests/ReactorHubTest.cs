using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace NuclearReactor.WebApi.IntegrationTests
{
    public class ReactorHubTest
    {
        [Fact]
        public async Task PressureUpdate_WaitFor15Seconds_PressureStaysWithinValidRange()
        {
            var config = GetConfiguration();

            var connection = GetTestServerConnection(config);

            var pressureUpdateWasCalled = false;

            connection.On<string>("pressureUpdate", result =>
            {
                var pressure = float.Parse(result, CultureInfo.InvariantCulture.NumberFormat);

                Assert.True(pressure > 0f);
                Assert.True(pressure < 0.9f);

                pressureUpdateWasCalled = true;
            });

            await connection.StartAsync();

            Thread.Sleep(15000);

            Assert.True(pressureUpdateWasCalled);
        }

        private static HubConnection GetTestServerConnection(IConfigurationRoot config)
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>().UseConfiguration(config);

            var server = new TestServer(webHostBuilder);
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost/pressurereading", o => o.HttpMessageHandlerFactory = _ => server.CreateHandler())
                .Build();
            return connection;
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var relativePath = @"../../../../NuclearReactor.WebApi";
            var absolutePath = Path.GetFullPath(relativePath);

            var config = new ConfigurationBuilder()
                .SetBasePath(absolutePath)
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config;
        }
    }
}