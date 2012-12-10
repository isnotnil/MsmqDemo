using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using MsmqDemo.Business;
using MsmqDemo.Services.Shared;

namespace MsmqDemo.Services
{ 
    public class SubmitOrderService : ISubmitOrderService
    {
        [OperationBehavior(TransactionAutoComplete = true,
                           TransactionScopeRequired = true)]
        public void SubmitOrderRequest(MsmqMessage<OrderRequest> message)
        {
            var request = message.Body;

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