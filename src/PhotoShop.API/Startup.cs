using FluentValidation.AspNetCore;
using PhotoShop.Core;
using PhotoShop.Core.Behaviours;
using PhotoShop.Core.Extensions;
using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Identity;
using PhotoShop.Infrastructure.Extensions;
using PhotoShop.Infrastructure;
using PhotoShop.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoShop.Core.Common;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace PhotoShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {                        
            services.AddSingleton<IDateTime, MachineDateTime>();
            services.AddSingleton<IEventStore, EventStore>();
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<ICommandPreProcessor, CommandPreProcessor>();
            services.AddSingleton<ICommandRegistry, CommandRegistry>();
            services.AddSingleton<IEventStoreMessageQueue, EventStoreMessageQueue>();
            services.AddHttpContextAccessor();
            services.AddHostedService<EventStoreMessageProcessor>();
            services.AddCustomMvc()
                .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            services
                .AddCustomSecurity(Configuration)
                .AddCustomSignalR()
                .AddCustomSwagger()
                .AddDataStore(Configuration["Data:DefaultConnection:ConnectionString"],Configuration.GetValue<bool>("isTest"))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthenticatedRequestBehavior<,>))
                .AddMediatR(typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            var repository = app.ApplicationServices.GetRequiredService<IRepository>() as IRepository;

            if(Configuration.GetValue<bool>("isTest"))
                app.UseMiddleware<ByPassAuthMiddleware>();
                    
            app.UseAuthentication()            
                .UseCors(CorsDefaults.Policy)            
                .UseMvc()
                .UseSignalR(routes => routes.MapHub<IntegrationEventsHub>("/hub"))
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoShop API");
                    options.RoutePrefix = string.Empty;
                });

            if (Configuration.GetValue<bool>("isCI"))
                new Timer((object stateInfo) => { Environment.Exit(0); }, null, 1000, 1000);

        }
    }
}
