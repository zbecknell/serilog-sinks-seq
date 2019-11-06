using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;

namespace Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			Log.Information("Blazor ConfigureServices() running");
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
			InitializeLogger();

			Log.Information("Blazor Configure() running");

            app.AddComponent<App>("app");
        }

		private void InitializeLogger()
		{
			// By sharing between the Seq sink and logger itself,
			// Seq API keys can be used to control the level of the whole logging pipeline.
			var levelSwitch = new LoggingLevelSwitch();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.BrowserConsole()
				.WriteTo.Seq("http://localhost:5341", controlLevelSwitch: levelSwitch)
				.CreateLogger();
		}
    }
}
