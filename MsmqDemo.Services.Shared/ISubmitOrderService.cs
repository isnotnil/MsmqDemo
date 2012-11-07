using System.ServiceModel;

namespace MsmqDemo.Services.Shared
{
    [ServiceContract(Name = "SubmitOrderService", Namespace = "http://isnotnil.net/msmq_demo")]
    public interface ISubmitOrderService
    {
        void SubmitOrderRequest(OrderRequest request);
    }
}