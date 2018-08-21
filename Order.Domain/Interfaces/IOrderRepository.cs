using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> Insert(Models.Order order);
        Task<Models.Order> GetByIdAsync(string id);
    }
}
