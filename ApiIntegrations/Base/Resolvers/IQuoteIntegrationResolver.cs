using Models.ApiIntegration;
using Shared.Models;
using Shared.Services;

namespace Base.Resolvers
{
    public interface IQuoteIntegrationResolver
    {
        IQuoteIntegrationService<IQuoteRequest, IQuoteResponse> Resolve(IntegrationPartner partner);
    }
}