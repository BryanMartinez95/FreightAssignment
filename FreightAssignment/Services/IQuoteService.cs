using System.Collections.Generic;
using System.Threading.Tasks;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;

namespace FreightAssignment.Services
{
    public interface IQuoteService
    {
        Task<List<RateModel>> GetRates(QuoteModel quoteModel);
        Task<RateModel> GetRate(IntegrationPartner partner, QuoteModel quoteModel);
    }
}