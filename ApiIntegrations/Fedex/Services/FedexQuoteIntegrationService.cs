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
    public class FedexQuoteIntegrationService: IQuoteIntegrationService
    {
        private string baseUrl = "http://localhost:7011";
        public IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Fedex;
        }

        public async Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            var quoteRequest = ConvertRequest(quoteModel);
            
            var rateResponse = await SendRequest(quoteRequest);
            
            return ConvertResponse(rateResponse);
        }

        public IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new FedexQuoteRequest
            {
                Consignee = quoteModel.SourceAddress,
                Consignor = quoteModel.DestinationAddress,
                Cartons = quoteModel.Cartons
            };
        }

        public RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (FedexRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Amount
            };
        }

        public async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .PostJsonAsync(quoteRequest)
                .ReceiveJson<FedexRateResponse>();
        }
    }
}