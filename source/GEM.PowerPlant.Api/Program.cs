using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace GEM.PowerPlant.Api
{
    public class Program
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true)
               .AddEnvironmentVariables()
               .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .WriteTo.Console()
                //.WriteTo.File(path: @"c:\temp\gem\powerplantlog.txt", outputTemplate: "{Timestamp:G} {Message}{NewLine:1}{Exception:1}")
                //.WriteTo.File(new JsonFormatter(), @"c:\temp\gem\powerplantlog.json", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://172.28.1.2:5341")
                .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
