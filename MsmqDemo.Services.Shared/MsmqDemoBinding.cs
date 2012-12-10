using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace MsmqDemo.Services.Shared
{
    public class MsmqDemoBinding
        : System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding
    {
        public MsmqDemoBinding()
        {
            ReceiveRetryCount = 1;
            MaxRetryCycles = 5;
            RetryCycleDelay = TimeSpan.FromMinutes(5);
            
            TimeToLive = TimeSpan.FromDays(7);

            SerializationFormat = MsmqMessageSerializationFormat.Xml;

            ReceiveErrorHandling = ReceiveErrorHandling.Move;

            Security.Mode = MsmqIntegrationSecurityMode.None;
            Security.Transport.MsmqAuthenticationMode = MsmqAuthenticationMode.None;
        }
    }
}