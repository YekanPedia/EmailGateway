namespace YekanPedia.EmailGateway.DeoendencyResolver.ServiceFactory
{
    using System;
    using System.ServiceModel;
    public class WcfServiceHost : ServiceHost
    {
        public WcfServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new WcfInstanceProvider(serviceType));
            }
        }
    }
}
