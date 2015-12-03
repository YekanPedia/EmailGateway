namespace YekanPedia.EmailGateway.Proxy.Model
{
    using System.Collections.Generic;
    public class EmailModel
    {
        public List<string> EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}