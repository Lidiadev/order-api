using Microsoft.Extensions.Configuration;
using System.IO;

namespace Order.Infrastructure
{
    public class Startup
    {
        public static IConfigurationRoot RegisterConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
