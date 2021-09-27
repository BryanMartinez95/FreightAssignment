using Models.ApiIntegration;
using Shared.Models;
using Shared.Services;

namespace Base.Factories
{
    public interface IQuoteIntegrationFactory
    {
        QuoteIntegrationService Resolve(IntegrationPartner partner);
    }
}