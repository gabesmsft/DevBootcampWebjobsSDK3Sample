using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DevBootcampWebJobSDKSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            builder.ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Information);
                    b.AddConsole();

                    // If this key exists in any config, use it to enable App Insights
                    string instrumentationKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                    if (!string.IsNullOrEmpty(instrumentationKey))
                    {
                        b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = instrumentationKey);
                    }
                })
                .UseConsoleLifetime();
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
