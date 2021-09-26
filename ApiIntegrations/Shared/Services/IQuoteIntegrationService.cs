using System.Threading.Tasks;
using Models.Quote;
using Models.Rate;
using Shared.Models;

namespace Shared.Services
{
    public interface IQuoteIntegrationService<out TRequest, in TResponse>
        where TRequest: IQuoteRequest
        where TResponse: IQuoteResponse
    {
        Task<RateModel> GetRate(QuoteModel quoteModel);

        TRequest ConvertRequest(QuoteModel quoteModel);

        RateModel ConvertResponse(TResponse response);
    }
}