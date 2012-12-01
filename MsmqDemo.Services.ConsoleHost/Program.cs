using System;
using System.ServiceModel;
using MsmqDemo.Services.Shared;

namespace MsmqDemo.Services.ConsoleHost
{
    class Program
    {
        static void Main()
        {
            try
            {
                var serviceHost = new ServiceHost(typeof (SubmitOrderService));
                serviceHost.AddServiceEndpoint(
                    typeof (ISubmitOrderService),
                    new MsmqDemoBinding(),
                    @"net.msmq://localhost/private/DemoQueue"
                    );

                serviceHost.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("...");
                Console.ReadLine();
            }
        }
    }
}
