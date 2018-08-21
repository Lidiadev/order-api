using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Order.Api.Models.Order
{
    [DataContract]
    public class OrderModel
    {
        /// <summary>
        /// The id of the new order
        /// </summary>
        [DataMember]
        [Required]
        public string OrderID { get; set; }

        [DataMember]
        public string TypeOfOrder { get; set; }

        [DataMember]
        public string SubmittedBy { get; set; }

        [DataMember]
        public string Partner { get; set; }

        [DataMember]
        public string CompanyID { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public IList<LineItemModel> LineItems { get; set; }
    }

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, Domain.Models.Order>();
        }
    }
}
