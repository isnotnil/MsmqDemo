using System;
using System.ServiceModel;

namespace MsmqDemo.Services.Shared
{
    public class MsmqDemoBinding
        : NetMsmqBinding
    {
        public MsmqDemoBinding()
        {
            ReceiveRetryCount = 1;
            MaxRetryCycles = 5;
            RetryCycleDelay = TimeSpan.FromMinutes(5);
            
            TimeToLive = TimeSpan.FromDays(7);

            ReceiveErrorHandling = ReceiveErrorHandling.Move;

            Security.Mode = NetMsmqSecurityMode.None;
            Security.Message.ClientCredentialType = MessageCredentialType.None;
            Security.Transport.MsmqAuthenticationMode = MsmqAuthenticationMode.None;
        }
    }
}