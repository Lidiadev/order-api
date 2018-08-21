using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = Startup.RegisterConfiguration();

            var services = new ServiceCollection();

            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceProvider.GetService<OrderContext>();

                context.Database.EnsureCreated();
            }
        }
    }
}
