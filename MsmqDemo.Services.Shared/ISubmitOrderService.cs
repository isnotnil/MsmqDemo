using System.ServiceModel;

namespace MsmqDemo.Services.Shared
{
    [ServiceContract(Name = "SubmitOrderService", 
        Namespace = "http://isnotnil.net/msmq_demo")]
    public interface ISubmitOrderService
    {
        [OperationContract]
        void SubmitOrderRequest(OrderRequest request);
    }
}