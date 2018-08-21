using Newtonsoft.Json;
using Order.Api.Models.Order;
using System;
using System.Collections.Generic;

namespace Order.IntegrationTests.Helpers
{
    public static class TestHelpers
    {
        public static string CreateWebsiteOrderModel()
        {
            var orderModel = new OrderModel()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductID = "1002",
                        ProductType = "Website",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        WebsiteDetails = new WebsiteDetailsModel
                        {
                            TemplateId = "TemplateId001"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }

        public static string CreateAdWordCampaingOrderModel()
        {
            var orderModel = new OrderModel()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductID = Guid.NewGuid().ToString("N"),
                        ProductType = "PaidSearch",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        AdWordCampaign = new AdWordCampaignModel
                        {
                            CampaignName = "Add Campaign"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }

        public static string CreateMixedOrderModel()
        {
            var orderModel = new OrderModel()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductID = Guid.NewGuid().ToString("N"),
                        ProductType = "Website",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        WebsiteDetails = new WebsiteDetailsModel
                        {
                            TemplateId = "TemplateId001"
                        }
                    },
                    new LineItemModel
                    {
                        ProductID = Guid.NewGuid().ToString("N"),
                        ProductType = "PaidSearch",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        AdWordCampaign = new AdWordCampaignModel
                        {
                            CampaignName = "Add Campaign"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }

        public static string CreateOrderInvalidProductTypeModel()
        {
            var orderModel = new OrderModel()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductID = Guid.NewGuid().ToString("N"),
                        ProductType = "InvalidProductType",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        WebsiteDetails = new WebsiteDetailsModel
                        {
                            TemplateId = "TemplateId001"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }

        public static string CreateOrderMissingIdModel()
        {
            var orderModel = new OrderModel()
            {
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductID = Guid.NewGuid().ToString("N"),
                        ProductType = "InvalidProductType",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        WebsiteDetails = new WebsiteDetailsModel
                        {
                            TemplateId = "TemplateId001"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }

        public static string CreateOrderMissingProductIdModel()
        {
            var orderModel = new OrderModel()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                LineItems = new List<LineItemModel>
                {
                    new LineItemModel
                    {
                        ProductType = "InvalidProductType",
                        Category = "Regular",
                        Notes = "Notes",
                        ProductName = "Product Name",
                        WebsiteDetails = new WebsiteDetailsModel
                        {
                            TemplateId = "TemplateId001"
                        }
                    }
                }
            };

            return JsonConvert.SerializeObject(orderModel);
        }
    }
}
