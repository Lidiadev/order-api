using Order.Api.Infrastructure.Exceptions;
using Order.Api.Models.Order;
using Order.Domain.Dtos;
using Order.Domain.ValueObjects;
using System;

namespace Order.Api.Extensions
{
    public static class LineItemExtensions
    {
        public static LineItemDto ToLineItemsDTO(this LineItemModel lineItem)
        {
            var isValid = Enum.TryParse(typeof(ProductType), lineItem.ProductType, out object productType);

            if (!isValid)
                throw new OrderException($"Product type {lineItem.ProductType} is not valid.");

            var lineItemDto = new LineItemDto
            {
                ProductID = lineItem.ProductID,
                Category = lineItem.Category,
                Notes = lineItem.Notes,
                ProductName = lineItem.ProductName,
                ProductType = (ProductType)productType
            };

            switch (lineItemDto.ProductType)
            {
                case ProductType.Website:
                    lineItemDto.WebsiteDetails = new WebsiteDetailsDto
                    {
                        TemplateId = lineItem.WebsiteDetails.TemplateId,
                        WebsiteAddressLine1 = lineItem.WebsiteDetails.WebsiteAddressLine1,
                        WebsiteAddressLine2 = lineItem.WebsiteDetails.WebsiteAddressLine2,
                        WebsiteBusinessName = lineItem.WebsiteDetails.WebsiteBusinessName,
                        WebsiteCity = lineItem.WebsiteDetails.WebsiteCity,
                        WebsiteEmail = lineItem.WebsiteDetails.WebsiteEmail,
                        WebsiteMobile = lineItem.WebsiteDetails.WebsiteMobile,
                        WebsitePhone = lineItem.WebsiteDetails.WebsitePhone,
                        WebsitePostCode = lineItem.WebsiteDetails.WebsitePostCode,
                        WebsiteState = lineItem.WebsiteDetails.WebsiteState,
                    };
                    break;
                case ProductType.PaidSearch:
                    lineItemDto.AdWordCampaign = new AdWordCampaignDto
                    {
                        CampaignName = lineItem.AdWordCampaign.CampaignName,
                        CampaignAddressLine1 = lineItem.AdWordCampaign.CampaignAddressLine1,
                        CampaignPostCode = lineItem.AdWordCampaign.CampaignPostCode,
                        CampaignRadius = lineItem.AdWordCampaign.CampaignRadius,
                        LeadPhoneNumber = lineItem.AdWordCampaign.LeadPhoneNumber,
                        SMSPhoneNumber = lineItem.AdWordCampaign.SMSPhoneNumber,
                        UniqueSellingPoint1 = lineItem.AdWordCampaign.UniqueSellingPoint1,
                        UniqueSellingPoint2 = lineItem.AdWordCampaign.UniqueSellingPoint2,
                        UniqueSellingPoint3 = lineItem.AdWordCampaign.UniqueSellingPoint3,
                        Offer = lineItem.AdWordCampaign.Offer,
                        DestinationURL = lineItem.AdWordCampaign.DestinationURL
                    };
                    break;

                default:
                    throw new OrderException($"Product type {lineItem.ProductType} is not valid.");
            }

            return lineItemDto;
        }
    }
}
