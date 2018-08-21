using System.Collections.Generic;

namespace Order.Domain.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string TypeOfOrder { get; set; }
        public string SubmittedBy { get; set; }
        public string Partner { get; set; }
        public string CompanyId { get; set; }

        public virtual Company CompanyNavigation { get; set; }

        //public virtual ICollection<Product.Product> Products { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }

        public Order()
        {

        }

        public Order(string id, string typeOfOrder, string submittedBy, string partner, Company company)
        {
            Id = id;
            TypeOfOrder = typeOfOrder;
            SubmittedBy = submittedBy;
            Partner = Partner;
            CompanyId = company.Id;
            CompanyNavigation = company;

            LineItems = new List<LineItem>();
        }

        public void AddItem(Product.Product product)
        {
            var lineItem = new LineItem(this, product);
            lineItem.OrderNavigation = this;
            lineItem.ProductNavigation = product;
            LineItems.Add(lineItem);
        }

        public void AddExistingItem(Product.Product product)
        {
            LineItems.Add(new LineItem(this, product));
        }
    }
}
