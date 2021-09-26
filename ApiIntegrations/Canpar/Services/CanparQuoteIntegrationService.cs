using System.Threading.Tasks;
using Canpar.Models;
using Flurl;
using Flurl.Http.Xml;
using Models.Quote;
using Models.Rate;
using Shared.Services;

namespace Canpar.Services
{
    public class CanparQuoteIntegrationService: IQuoteIntegrationService<CanparQuoteRequest,CanparQuoteResponse>
    {
        private string baseUrl = "http://localhost:7011";
        
        public async Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            var quoteRequest = ConvertRequest(quoteModel);
            
            var rateResponse = await baseUrl
                .AppendPathSegment("quote")
                .PostXmlAsync(quoteRequest)
                .ReceiveXml<CanparQuoteResponse>();
            
            return ConvertResponse(rateResponse);
        }

        public CanparQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            throw new System.NotImplementedException();
        }

        public RateModel ConvertResponse(CanparQuoteResponse response)
        {
            throw new System.NotImplementedException();
        }
    }
}