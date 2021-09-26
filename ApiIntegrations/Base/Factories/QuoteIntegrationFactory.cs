using System;
using Canpar.Services;
using Models.ApiIntegration;    
using Shared.Services;

namespace Base.Factories
{
    public class QuoteIntegrationFactory : IQuoteIntegrationFactory
    {
        public IQuoteIntegrationService Resolve(IntegrationPartner partner)
        {
            switch (partner)
            {
                case IntegrationPartner.Canpar:
                case IntegrationPartner.Fedex:
                case IntegrationPartner.Purolator:
                    return new CanparQuoteIntegrationService();
                default:
                    throw new Exception("Integration Partner Not Registered");
                
            }
        }
        
    }
}