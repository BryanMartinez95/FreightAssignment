using System.Threading.Tasks;
using Fedex.Models;
using Flurl;
using Flurl.Http;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Shared.Models;
using Shared.Services;

namespace Fedex.Services
{
    public class FedexQuoteIntegrationService: QuoteIntegrationService
    {
        private string baseUrl = "http://localhost:7012";

        protected override IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Fedex;
        }
        
        public override IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new FedexQuoteRequest
            {
                Consignee = quoteModel.SourceAddress,
                Consignor = quoteModel.DestinationAddress,
                Cartons = quoteModel.Cartons
            };
        }

        public override RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (FedexRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Amount
            };
        }

        protected override async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .AppendPathSegment("ShippingQuote")
                .PostJsonAsync(quoteRequest)
                .ReceiveJson<FedexRateResponse>();
        }
    }
}