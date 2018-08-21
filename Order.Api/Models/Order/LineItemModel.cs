using System.ComponentModel.DataAnnotations;

namespace Order.Api.Models.Order
{
    public class LineItemModel
    {
        /// <summary>
        /// The id of the product associated with the order
        /// </summary>
        [Required]
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }

        /// <summary>
        /// The type of the product
        /// Acceptable values are:
        /// - Website
        /// - PaidSearch
        /// </summary>
        [Required]
        public string ProductType { get; set; }

        public WebsiteDetailsModel WebsiteDetails { get; set; }

        public AdWordCampaignModel AdWordCampaign { get; set; }
    }
}
