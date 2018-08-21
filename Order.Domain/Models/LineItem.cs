namespace Order.Domain.Models
{
    public class LineItem
    {
        public string ProductId { get; set; }
        public string OrderOd { get; set; }
      
        public virtual Product.Product ProductNavigation { get; set; }
        public virtual Order OrderNavigation { get; set; }

        public LineItem()
        {

        }

        public LineItem(Order order, Product.Product product)
        {
            ProductId = product.Id;
            OrderOd = order.Id;
        }
    }
}
