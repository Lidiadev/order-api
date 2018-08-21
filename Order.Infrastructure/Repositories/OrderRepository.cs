using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public Task<Domain.Models.Order> GetByIdAsync(string id)
        {
            return _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> Insert(Domain.Models.Order order)
        {
            _context.Orders.Add(order);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
