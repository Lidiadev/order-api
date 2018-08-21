using Order.Api.Models.Order;
using System.Threading.Tasks;

namespace Order.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> SaveAsync(OrderModel order);
    }
}
