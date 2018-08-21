using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Models.Order;
using Order.Api.Services.Interfaces;

namespace Order.Api.Controllers
{
    /// <summary>
    /// The Order Controller offers support to create a new order
    /// </summary>
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST api/<controller>
        /// <summary>
        /// Creates a new Order
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Order
        ///     { 
        ///       "Partner": "Partner A",
        ///       "OrderID": "10001",
        ///       "TypeOfOrder": "Regular",
        ///       "SubmittedBy": "Partner",
        ///       "CompanyID": "101",
        ///       "CompanyName": "Company A",
        ///       "LineItems": [
        ///       {
        ///         "ID": "1002",
        ///         "ProductID": "1003",
        ///         "ProductType": "Website",
        ///         "Notes": "Regular Website Product",
        ///         "Category": "Regular",
        ///         "WebsiteDetails": {
        ///             "TemplateId": "sample string 245",
        ///             "WebsiteBusinessName": "sample string 245",
        ///             "WebsiteAddressLine1": "sample string 246",
        ///             "WebsiteAddressLine2": "sample string 247",
        ///             "WebsiteCity": "sample string 248",
        ///             "WebsiteState": "sample string 249",
        ///             "WebsitePostCode": "sample string 250",
        ///             "WebsitePhone": "sample string 257",
        ///             "WebsiteEmail": "sample string 258",
        ///             "WebsiteMobile": "sample string 259"
        ///          }
        ///         }
        ///        ]
        ///      }
        ///
        /// </remarks>
        /// <param name="model">The model for the new order</param>
        /// <returns>Ok</returns>
        /// <response code="200">Returns ok if the order was successfully created</response>
        /// <response code="400">If the order couldn't be saved</response>  
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]OrderModel model)
        { 
            var result = await _orderService.SaveAsync(model);

            return result ? (IActionResult)Ok() : (IActionResult)BadRequest();
        }
    }
}
