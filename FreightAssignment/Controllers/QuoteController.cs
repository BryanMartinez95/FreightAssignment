using System.Collections.Generic;
using System.Threading.Tasks;
using FreightAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiIntegration;
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
        
        
        /// <summary>
        /// Quotes all integrated partners and returns cheapest rate
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "SourceAddress": "123 abc street",
        ///        "DestinationAddress": "432 ASF street",
        ///        "Cartons": {"Package 1", "Package 2"}
        ///     }
        ///
        /// </remarks>
        /// <param name="quoteModel"></param>
        /// <returns> A list of Rates</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("QuotePartners")]
        public async Task<IActionResult> QuotePartners(QuoteModel quoteModel)
        {
            
            return Ok(await _quoteService.QuotePartners(quoteModel));
        }


        /// <summary>
        /// Get a quote from a single integrated partner
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///        "SourceAddress": "123 abc street",
        ///        "DestinationAddress": "432 ASF street",
        ///        "Cartons": {"Package 1", "Package 2"}
        ///     }
        /// 
        /// </remarks>
        /// <param name="partner"></param>
        /// <param name="quoteModel"></param>
        /// <returns>Shipping Rate</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("QuotePartner")]
        public async Task<IActionResult> QuotePartner(IntegrationPartner partner,QuoteModel quoteModel)
        {
            
            return Ok(await _quoteService.QuotePartner(partner, quoteModel));
        }
    }
}