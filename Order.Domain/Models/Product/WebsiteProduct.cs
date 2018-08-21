using Order.Domain.Dtos;

namespace Order.Domain.Models.Product
{
    public class WebsiteProduct : Product
    {
        public string TemplateId { get; set; }
        public string BusinessName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public WebsiteProduct()
        {

        }

        public WebsiteProduct(LineItemDto lineItemDto) 
            : base(lineItemDto.ProductID, lineItemDto.ProductType, lineItemDto.Notes, lineItemDto.Category)
        {
            TemplateId = lineItemDto.WebsiteDetails.TemplateId;
            BusinessName = lineItemDto.WebsiteDetails.WebsiteBusinessName;
            AddressLine1 = lineItemDto.WebsiteDetails.WebsiteAddressLine1;
            AddressLine2 = lineItemDto.WebsiteDetails.WebsiteAddressLine2;
            City = lineItemDto.WebsiteDetails.WebsiteCity;
            State = lineItemDto.WebsiteDetails.WebsiteState;
            PostCode = lineItemDto.WebsiteDetails.WebsitePostCode;
            Phone = lineItemDto.WebsiteDetails.WebsitePhone;
            Email = lineItemDto.WebsiteDetails.WebsiteEmail;
            Mobile = lineItemDto.WebsiteDetails.WebsiteMobile;
        }
    }
}
