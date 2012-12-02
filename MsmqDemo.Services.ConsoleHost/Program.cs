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
                
                // TODO: Add Service Endpoint

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
