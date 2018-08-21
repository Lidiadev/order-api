using Microsoft.EntityFrameworkCore;
using Order.Domain.Models;
using Order.Domain.Models.Product;

namespace Order.Infrastructure
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {

        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Models.Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PaidSearchProduct> PaidSearchProducts { get; set; }
        public DbSet<WebsiteProduct> WebsitesProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineItem>()
            .HasKey(e => new { e.ProductId, e.OrderOd });

            modelBuilder.Entity<LineItem>()
                .HasOne(pt => pt.ProductNavigation)
                .WithMany(p => p .LineItems)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<LineItem>()
                .HasOne(pt => pt.OrderNavigation)
                .WithMany(t => t.LineItems)
                .HasForeignKey(pt => pt.OrderOd);
        }
    }
}
