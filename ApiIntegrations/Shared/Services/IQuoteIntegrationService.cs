using System.Threading.Tasks;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Shared.Models;

namespace Shared.Services
{
    public interface IQuoteIntegrationService
    {
        IntegrationPartner GetIntegrationPartner();
        Task<RateModel> GetRate(QuoteModel quoteModel);

        IQuoteRequest ConvertRequest(QuoteModel quoteModel);

        RateModel ConvertResponse(IRateResponse response);

        Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest);
    }
}