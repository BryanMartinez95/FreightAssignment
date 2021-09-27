using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Purolator.Models;
using Shared.Models;
using Shared.Services;

namespace Purolator.Services
{
    public class PurolatorQuoteIntegrationService: IQuoteIntegrationService
    {
        private string baseUrl = "http://localhost:7013";
        public async Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            var quoteRequest = ConvertRequest(quoteModel);
            
            var rateResponse = await SendRequest(quoteRequest);
            
            return ConvertResponse(rateResponse);
        }

        public IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new PurolatorQuoteRequest
            {
                ContactAddress = quoteModel.SourceAddress,
                WarehouseAddress = quoteModel.DestinationAddress,
                PackageDimensions = quoteModel.Cartons
            };
        }

        public RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (PurolatorRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Total
            };
        }

        public async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .PostJsonAsync(quoteRequest)
                .ReceiveJson<PurolatorRateResponse>();
        }
        
        public IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Purolator;
        }

    }
}