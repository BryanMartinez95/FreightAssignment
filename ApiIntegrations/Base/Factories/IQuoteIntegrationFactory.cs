using Models.ApiIntegration;
using Shared.Models;
using Shared.Services;

namespace Base.Factories
{
    public interface IQuoteIntegrationFactory
    {
        IQuoteIntegrationService Resolve(IntegrationPartner partner);
    }
}