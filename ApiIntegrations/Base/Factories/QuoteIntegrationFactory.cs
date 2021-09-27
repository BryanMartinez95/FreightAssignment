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
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        public QuoteIntegrationService Resolve(IntegrationPartner partner)
        {
            switch (partner)
            {
                case IntegrationPartner.Canpar:
                   return new CanparQuoteIntegrationService();
                case IntegrationPartner.Fedex:
                    return new FedexQuoteIntegrationService();
                case IntegrationPartner.Purolator:
                    return new PurolatorQuoteIntegrationService();
                default:
                    Logger.Warn($"{partner.ToString()} not registered for QuoteIntegrationFactory");
                    return null;
            }
        }
        
    }
}
