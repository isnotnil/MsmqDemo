using System;
using System.Linq;
using System.ServiceModel;
using MsmqDemo.Services.Shared;

namespace Msmq.Client.Slammer
{
    class Program
    {
        static void Main()
        {
            Enumerable.Range(0, 1).AsParallel().ForAll(
                (i) =>
                    {
                        var channel = new ChannelFactory<ISubmitOrderService>(
                            new MsmqDemoBinding(),
                            "net.msmq://DemoServer/private/MsmqDemo/SubmitOrderService.svc"
                            );
                        var client = channel.CreateChannel();
                        var orderRequest = new OrderRequest
                                               {
                                                   ConfirmationEmailAddress = @"test@test.com",
                                                   RequestedDeliveryDate = DateTime.Now,
                                                   VendorNumber = "1"
                                               };
                        orderRequest.LineItems.Add(new OrderLineItem
                                                       {
                                                           ProductIdentifier = @"Blah",
                                                           Quanity = 42
                                                       });
                        client.SubmitOrderRequest(orderRequest);
                    }
                );
        }
    }
}
