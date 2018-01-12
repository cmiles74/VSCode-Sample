using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Serilog;
using Working.Models;
using Microsoft.Extensions.PlatformAbstractions;

namespace Working
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set the comments path for the Swagger JSON and UI.
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var xmlDocPath = Path.Combine(basePath, "CTSimsInquiry.xml");

            services.AddLogging(lb => lb.AddSerilog(dispose: true));
            services.AddDbContext<WorkingContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("Logs/log-{Date}.txt")
                .CreateLogger();

            loggerFactory.AddSerilog();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}