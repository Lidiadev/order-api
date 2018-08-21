using Order.Domain.ValueObjects;

namespace Order.Domain.Dtos
{
    public class LineItemDto
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }

        public ProductType ProductType { get; set; }

        public AdWordCampaignDto AdWordCampaign { get; set; }

        public WebsiteDetailsDto WebsiteDetails { get; set; }
    }
}
