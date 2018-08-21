using Order.Domain.Dtos;

namespace Order.Domain.Models.Product
{
    public class PaidSearchProduct : Product
    {
        public string CampaignName { get; set; }
        public string CampaignAddressLine1 { get; set; }
        public string CampaignPostCode { get; set; }
        public string CampaignRadius { get; set; }
        public string LeadPhoneNumber { get; set; }
        public string SMSPhoneNumber { get; set; }
        public string UniqueSellingPoint1 { get; set; }
        public string UniqueSellingPoint2 { get; set; }
        public string UniqueSellingPoint3 { get; set; }
        public string Offer { get; set; }
        public string DestinationURL { get; set; }

        public PaidSearchProduct()
        {

        }

        public PaidSearchProduct(LineItemDto lineItemDto)
            : base(lineItemDto.ProductID, lineItemDto.ProductType, lineItemDto.Notes, lineItemDto.Category)
        {
            CampaignName = lineItemDto.AdWordCampaign.CampaignName;
            CampaignAddressLine1 = lineItemDto.AdWordCampaign.CampaignAddressLine1;
            CampaignPostCode = lineItemDto.AdWordCampaign.CampaignPostCode;
            CampaignRadius = lineItemDto.AdWordCampaign.CampaignRadius;
            LeadPhoneNumber = lineItemDto.AdWordCampaign.LeadPhoneNumber;
            SMSPhoneNumber = lineItemDto.AdWordCampaign.SMSPhoneNumber;
            UniqueSellingPoint1 = lineItemDto.AdWordCampaign.UniqueSellingPoint1;
            UniqueSellingPoint2 = lineItemDto.AdWordCampaign.UniqueSellingPoint2;
            UniqueSellingPoint3 = lineItemDto.AdWordCampaign.UniqueSellingPoint3;
            Offer = lineItemDto.AdWordCampaign.Offer;
            DestinationURL = lineItemDto.AdWordCampaign.DestinationURL;
        }
    }
}
