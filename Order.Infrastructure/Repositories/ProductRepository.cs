using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Models.Product;

namespace Order.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderContext _context;

        public ProductRepository(OrderContext context)
        {
            _context = context;
        }

        public Task<Product> GetByIdAsync(string id)
        {
            return _context.Products.FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
