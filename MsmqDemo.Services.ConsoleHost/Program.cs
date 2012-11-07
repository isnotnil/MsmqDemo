using System;
using System.ServiceModel;

namespace MsmqDemo.Services.ConsoleHost
{
    class Program
    {
        static void Main()
        {
            try
            {
                var serviceHost = new ServiceHost(typeof (SubmitOrderService));

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
