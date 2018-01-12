using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace Working
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .CreateLogger();

            try
            {
                Log.Information("Starting web host");

                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IWebHost BuildWebHost(string[] args) {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000;")
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
        }
    }
}
