using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuclearReactor.Core;
using NuclearReactor.Core.Contracts;
using NuclearReactor.WebApi.HostedServices;
using NuclearReactor.WebApi.Hubs;

namespace NuclearReactor.WebApi
{
    public class Startup
    {
        private const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var allowedOrigins = Configuration["AllowedOrigins"];

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder.WithOrigins(allowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddHostedService<ControlTimerService>();

            services.AddSingleton<IPressureSensor, PressureSensor>();
            services.AddSingleton<IPressureContainer, Core.NuclearReactor>();
            services.AddSingleton<IValveControl, ValveControl>();
            services.AddSingleton<IControlUnit, ControlUnit>();

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.UseCors(CorsPolicy);
            app.UseSignalR(routes => routes.MapHub<ReactorHub>("/pressurereading"));
            app.UseMvc();
        }
    }
}