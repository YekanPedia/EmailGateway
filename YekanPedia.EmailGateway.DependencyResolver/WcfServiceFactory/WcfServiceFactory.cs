namespace YekanPedia.EmailGateway.DeoendencyResolver.ServiceFactory
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    public class WcfServiceFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new WcfServiceHost(serviceType, baseAddresses);
        }
    }
}
