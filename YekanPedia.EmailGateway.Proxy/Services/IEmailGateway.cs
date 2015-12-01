namespace YekanPedia.EmailGateway.Proxy.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Model;

    [ServiceContract]
    public interface IEmailGateway
    {
        [OperationContract(IsOneWay = true)]
        void SendSimpleEmail(List<EmailModel> model);
    }
}
