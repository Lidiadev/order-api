using Order.Domain.Dtos;
using Order.Domain.Models.Product;

namespace Order.Domain.Factories
{
    public interface IProductFactory
    {
        Product CreateProduct(LineItemDto lineItemDto);
    }
}
