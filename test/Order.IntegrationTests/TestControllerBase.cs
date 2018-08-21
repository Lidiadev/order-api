using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Order.Infrastructure;
using System.IO;
using System.Reflection;

namespace Order.IntegrationTests
{
    public class TestControllerBase
    {
        private DbContextOptions<OrderContext> _contextOptions;

        public TestServer CreateTestServer()
        {
            var path = Assembly.GetAssembly(typeof(TestControllerBase)).Location;

            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(path))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var builder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(context => config.Build()).UseStartup<Api.Startup>();

            var testServer = new TestServer(builder);

            // ToDo : fix to get the connection string from appsettings.json
            _contextOptions = new DbContextOptionsBuilder<OrderContext>()
                .UseSqlServer("Server=.\\;Database=OrderDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            SeedData();

            return testServer;
        }

        public virtual void SeedData()
        {
            using (var c = new OrderContext(_contextOptions))
            {
                c.Database.EnsureCreated();
            }
        }
    }
}
