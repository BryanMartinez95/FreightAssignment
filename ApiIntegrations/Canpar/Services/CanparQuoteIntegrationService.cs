using System.Threading.Tasks;
using Canpar.Models;
using Flurl;
using Flurl.Http.Xml;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Shared.Models;
using Shared.Services;

namespace Canpar.Services
{
    public class CanparQuoteIntegrationService: IQuoteIntegrationService
    {
        private string baseUrl = "http://localhost:7012";
        
        public async Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            var quoteRequest = ConvertRequest(quoteModel);
            
            var rateResponse = await SendRequest(quoteRequest);
            
            return ConvertResponse(rateResponse);
        }

        public async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .PostXmlAsync(quoteRequest)
                .ReceiveXml<CanparRateResponse>();
        }

        public IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new CanparQuoteRequest
            {
                Source = quoteModel.SourceAddress,
                Destination = quoteModel.DestinationAddress,
                Packages = quoteModel.Cartons
            };
        }
        
        public RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (CanparRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Quote
            };
        }

        public IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Canpar;
        }
    }
}