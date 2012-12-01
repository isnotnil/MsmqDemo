using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using MsmqDemo.Business;
using MsmqDemo.Services.Shared;

namespace MsmqDemo.Services
{
    [ServiceBehavior(Name = "throttleIt", 
        InstanceContextMode = InstanceContextMode.PerCall, 
        ReleaseServiceInstanceOnTransactionComplete = true)]   
    public class SubmitOrderService : ISubmitOrderService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitOrderRequest(OrderRequest request)
        {
            using (var db = new OrderDataContext())
            {
                var order = new OrderEntity
                                {
                                    ConfirmationEmailAddress = request.ConfirmationEmailAddress,
                                    DateCreated = DateTime.Now,
                                    RequestedDeliveryDate = request.RequestedDeliveryDate,
                                    VendorNumber = request.VendorNumber,
                                    OrderItems = new Collection<OrderItemEntity>()
                                };

                foreach(var item in request.LineItems)
                {
                    var orderItem = new OrderItemEntity
                                        {
                                            ProductIdentifier = item.ProductIdentifier, 
                                            Quantity = item.Quanity
                                        };

                    order.OrderItems.Add(orderItem);
                }

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}