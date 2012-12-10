using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace MsmqDemo.Services.Shared
{
    [ServiceContract(Name = "SubmitOrderService", 
        Namespace = "http://isnotnil.net/msmq_demo")]
    [ServiceKnownType(typeof(OrderRequest))]
    public interface ISubmitOrderService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitOrderRequest(MsmqMessage<OrderRequest> request);
    }
}