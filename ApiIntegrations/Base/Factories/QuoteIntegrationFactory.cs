using System;
using Canpar.Services;
using Fedex.Services;
using Models.ApiIntegration;
using Purolator.Services;
using Shared.Services;

namespace Base.Factories
{
    public class QuoteIntegrationFactory : IQuoteIntegrationFactory
    {
        public IQuoteIntegrationService Resolve(IntegrationPartner partner)
        {
            return partner switch
            {
                IntegrationPartner.Canpar => new CanparQuoteIntegrationService(),
                IntegrationPartner.Fedex => new FedexQuoteIntegrationService(),
                IntegrationPartner.Purolator => new PurolatorQuoteIntegrationService(),
                _ => throw new Exception("Integration Partner Not Registered")
            };
        }
        
    }
}