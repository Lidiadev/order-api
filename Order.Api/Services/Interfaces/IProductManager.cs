using Order.Domain.Dtos;
using Order.Domain.Models.Product;

namespace Order.Api.Services.Interfaces
{
    public interface IProductManager
    {
        Product OrderProduct(LineItemDto lineItemDto);
    }
}
