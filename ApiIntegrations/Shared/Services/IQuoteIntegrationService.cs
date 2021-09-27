using System.Threading.Tasks;
using Models.Quote;
using Models.Rate;
using Shared.Models;

namespace Shared.Services
{
    public interface IQuoteIntegrationService
    {
        Task<RateModel> GetRate(QuoteModel quoteModel);

        IQuoteRequest ConvertRequest(QuoteModel quoteModel);

        RateModel ConvertResponse(IRateResponse response);
    }
}