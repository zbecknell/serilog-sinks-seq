using Microsoft.AspNetCore.Blazor.Hosting;
using Serilog;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.BrowserConsole()
				.CreateLogger();

			try
			{
				Log.Information("Blazor app starting");
				CreateHostBuilder(args).Build().Run();
			}
			catch (System.Exception)
			{
				Log.CloseAndFlush();
				throw;
			}
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
