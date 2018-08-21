using Order.Domain.Models.Product;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(string id);
    }
}
