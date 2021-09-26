using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Quote;
using Models.Rate;

namespace FreightAssignment.Services
{
    public interface IQuoteService
    {
        Task<List<RateModel>> Quote(QuoteModel quoteModel);
    }
}