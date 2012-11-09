using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MsmqDemo.Services.Shared
{
    [DataContract(Namespace = "http://isnotnil.net/msmq_demo")]
    public class OrderRequest
    {
        public OrderRequest()
        {
            LineItems = new List<OrderLineItem>();
        }

        [DataMember]
        public string VendorNumber { get; set; }

        [DataMember]
        public DateTime RequestedDeliveryDate { get; set; }

        [DataMember]
        public string ConfirmationEmailAddress { get; set; }

        [DataMember]
        public IList<OrderLineItem> LineItems { get; set; }
    }
}