using System.Threading.Tasks;
using Models.Quote;
using Models.Rate;
using Shared.Models;
using Shared.Services;

namespace Fedex.Services
{
    public class FedexQuoteIntegrationService: IQuoteIntegrationService
    {
        public Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            throw new System.NotImplementedException();
        }

        public IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            throw new System.NotImplementedException();
        }

        public RateModel ConvertResponse(IRateResponse response)
        {
            throw new System.NotImplementedException();
        }
    }
}