using Microsoft.Extensions.DependencyInjection;
using System.ServiceProcess;

namespace Task3WindowsService
{
    static class Program
    {
        /// <summary>
        /// Service container for dependency injections
        /// </summary>
        static ServiceProvider _container;

        static Program()
        {
            // Create dependency enjection service collection
            ServiceCollection services = new ServiceCollection();
            // Configure collection
            ConfigureServices(services);
            // Create service collection container
            _container = services.BuildServiceProvider();
        }


        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services">Service collection</param>
        static void ConfigureServices(ServiceCollection services)
        {
            // Add services to the collection
            services.AddSingleton<FileWatcher>();
            services.AddSingleton<TimerBuilder>();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Constuctor for the service array
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                (ServiceBase)_container.GetRequiredService(typeof(FileWatcher))
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
