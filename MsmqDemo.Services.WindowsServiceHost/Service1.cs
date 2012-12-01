using System.ServiceModel;
using System.ServiceProcess;
using MsmqDemo.Services.Shared;

namespace MsmqDemo.Services.WindowsServiceHost
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost _serviceHost;

        public Service1()
        {
            InitializeComponent();

            _serviceHost = new ServiceHost(typeof(SubmitOrderService));
            _serviceHost.AddServiceEndpoint(
                typeof(ISubmitOrderService),
                new MsmqDemoBinding(),
                @"net.msmq://localhost/private/DemoQueue"
                );
        }

        protected override void OnStart(string[] args)
        {
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            _serviceHost.Close();
        }
    }
}
