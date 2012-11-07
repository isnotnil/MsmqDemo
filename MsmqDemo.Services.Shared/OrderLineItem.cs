using System.Runtime.Serialization;

namespace MsmqDemo.Services.Shared
{
    [DataContract(Namespace = "http://isnotnil.net/msmq_demo")]
    public class OrderLineItem
    {
        [DataMember]
        public int Quanity { get; set; }

        [DataMember]
        public string ProductIdentifier { get; set; }
    }
}