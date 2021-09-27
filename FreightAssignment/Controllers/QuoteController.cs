using System.Collections.Generic;
using System.Threading.Tasks;
using FreightAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Quote;
using Models.Rate;

namespace FreightAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        private IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }
        
        
        [HttpGet]
        public Task<List<RateModel>> Quote()
        {
            return _quoteService.GetRates(new QuoteModel());
        }
    }
}