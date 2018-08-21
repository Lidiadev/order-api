using AutoFixture;
using Order.Api.Extensions;
using Order.Api.Infrastructure.Exceptions;
using Order.Api.Models.Order;
using Order.Domain.Dtos;
using Xunit;

namespace Order.UnitTests.Extensions
{
    public class LineItemExtensionsTests
    {
        [Fact]
        public void LineModel_to_website_line_model()
        {
            // ARRANGE
            var lineItem = CreateWebsiteDetailsModel();

            // ACT
            var lineItemDto = lineItem.ToLineItemsDTO();

            // ASSERT
            Assert.NotNull(lineItemDto);
            AssertOrder(lineItem, lineItemDto);
            Assert.NotNull(lineItemDto.WebsiteDetails);
            Assert.Equal(lineItemDto.WebsiteDetails.TemplateId, lineItem.WebsiteDetails.TemplateId);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteAddressLine1, lineItem.WebsiteDetails.WebsiteAddressLine1);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteAddressLine2, lineItem.WebsiteDetails.WebsiteAddressLine2);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteBusinessName, lineItem.WebsiteDetails.WebsiteBusinessName);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteCity, lineItem.WebsiteDetails.WebsiteCity);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteEmail, lineItem.WebsiteDetails.WebsiteEmail);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteMobile, lineItem.WebsiteDetails.WebsiteMobile);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsitePhone, lineItem.WebsiteDetails.WebsitePhone);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsitePostCode, lineItem.WebsiteDetails.WebsitePostCode);
            Assert.Equal(lineItemDto.WebsiteDetails.WebsiteState, lineItem.WebsiteDetails.WebsiteState);
        }

        [Fact]
        public void LineModel_to_adwordcampaing_line_model()
        {
            // ARRANGE
            var lineItem = AdWordCampaignModel();

            // ACT
            var lineItemDto = lineItem.ToLineItemsDTO();

            // ASSERT
            Assert.NotNull(lineItemDto);
            AssertOrder(lineItem, lineItemDto);
            Assert.NotNull(lineItemDto.AdWordCampaign);
            Assert.Equal(lineItemDto.AdWordCampaign.CampaignAddressLine1, lineItem.AdWordCampaign.CampaignAddressLine1);
            Assert.Equal(lineItemDto.AdWordCampaign.CampaignName, lineItem.AdWordCampaign.CampaignName);
            Assert.Equal(lineItemDto.AdWordCampaign.CampaignPostCode, lineItem.AdWordCampaign.CampaignPostCode);
            Assert.Equal(lineItemDto.AdWordCampaign.CampaignRadius, lineItem.AdWordCampaign.CampaignRadius);
            Assert.Equal(lineItemDto.AdWordCampaign.DestinationURL, lineItem.AdWordCampaign.DestinationURL);
            Assert.Equal(lineItemDto.AdWordCampaign.LeadPhoneNumber, lineItem.AdWordCampaign.LeadPhoneNumber);
            Assert.Equal(lineItemDto.AdWordCampaign.SMSPhoneNumber, lineItem.AdWordCampaign.SMSPhoneNumber);
            Assert.Equal(lineItemDto.AdWordCampaign.UniqueSellingPoint1, lineItem.AdWordCampaign.UniqueSellingPoint1);
            Assert.Equal(lineItemDto.AdWordCampaign.UniqueSellingPoint2, lineItem.AdWordCampaign.UniqueSellingPoint2);
            Assert.Equal(lineItemDto.AdWordCampaign.UniqueSellingPoint3, lineItem.AdWordCampaign.UniqueSellingPoint3);
        }

        [Fact]
        public void LineModel_with_invalid_product_type_throws_exception()
        {
            // ARRANGE
            var lineItem = InvalidLineModel();

            // ACT
            // ASSERT
            Assert.Throws<OrderException>(() => lineItem.ToLineItemsDTO());
        }

        private void AssertOrder(LineItemModel lineItem, LineItemDto lineItemDto)
        {
            Assert.Equal(lineItemDto.Category, lineItem.Category);
            Assert.Equal(lineItemDto.Notes, lineItem.Notes);
            Assert.Equal(lineItemDto.ProductName, lineItem.ProductName);
            Assert.Equal(lineItemDto.ProductID, lineItem.ProductID);
            Assert.Equal(lineItemDto.ProductType.ToString(), lineItem.ProductType);
        }

        private LineItemModel CreateWebsiteDetailsModel()
            => new LineItemModel
            {
                ProductID = "1001",
                ProductType = "Website",
                Category = "Regular",
                Notes = "Notes",
                ProductName = "Product Name",
                WebsiteDetails = new Fixture().Create<WebsiteDetailsModel>() 
            };

        private LineItemModel AdWordCampaignModel()
            => new LineItemModel
            {
                ProductID = "1001",
                ProductType = "PaidSearch",
                Category = "Regular",
                Notes = "Notes",
                ProductName = "Product Name",
                AdWordCampaign = new Fixture().Create<AdWordCampaignModel>()
            };

        private LineItemModel InvalidLineModel()
            => new LineItemModel
            {
                ProductID = "1001",
                ProductType = "Product",
                Category = "Regular",
                Notes = "Notes",
                ProductName = "Product Name",
            };
    }
}
