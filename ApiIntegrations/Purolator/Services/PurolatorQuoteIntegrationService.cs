using System.Threading.Tasks;
using Models.Quote;
using Models.Rate;
using Shared.Models;
using Shared.Services;

namespace Purolator.Services
{
    public class PurolatorQuoteIntegrationService: IQuoteIntegrationService
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