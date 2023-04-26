using Microsoft.Extensions.DependencyInjection;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using WorkPickUp.Data;

namespace WorkPickUp
{
    public class Startup : IStartup
    {
        public void Configure(IServiceCollection services)
        {
            // TODO: Add services and systems to the services collection
            services.AddSystem<LoginSystem>();
            services.AddSystem<WorkSystem>();
            services.AddTransient<IWorldService, WorldService>();
            
        }

        public void Configure(IEcsBuilder builder)
        {
            // TODO: Enable desired ECS system features
            builder.EnableSampEvents()
                .EnablePlayerCommands()
                .EnableRconCommands();
            //builder.EnableEvent<int, int>("OnPlayerPickUpPickup");
            var world = builder.Services.GetServices<IWorldService>();
        }
    }
}