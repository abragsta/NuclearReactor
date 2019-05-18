using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuclearReactor.Core;
using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.HostedServices;

namespace NuclearReactor.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHostedService<ControlTimerService>();

            services.AddTransient<IPressureSensor, PressureSensor>();
            services.AddTransient<IPressureContainer, Core.NuclearReactor>();
            services.AddTransient<IValveControl, ValveControl>();
            services.AddTransient<IControlUnit, ControlUnit>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
