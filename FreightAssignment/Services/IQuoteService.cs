using System.Collections.Generic;
using System.Threading.Tasks;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;

namespace FreightAssignment.Services
{
    public interface IQuoteService
    {
        Task<RateModel> QuotePartners(QuoteModel quoteModel);
        Task<RateModel> QuotePartner(IntegrationPartner partner, QuoteModel quoteModel);
    }
}