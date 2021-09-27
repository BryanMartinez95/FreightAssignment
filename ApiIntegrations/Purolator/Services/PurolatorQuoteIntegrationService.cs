using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Purolator.Models;
using Shared.Models;
using Shared.Services;

namespace Purolator.Services
{
    public class PurolatorQuoteIntegrationService: QuoteIntegrationService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private string baseUrl = "http://localhost:7013";

        public override IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new PurolatorQuoteRequest
            {
                ContactAddress = quoteModel.DestinationAddress,
                WarehouseAddress = quoteModel.SourceAddress,
                PackageDimensions = quoteModel.Cartons
            };
        }

        public override RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (PurolatorRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Total
            };
        }

        protected override async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .AppendPathSegment("TransportationCost")
                .PostJsonAsync(quoteRequest)
                .ReceiveJson<PurolatorRateResponse>();
        }

        protected override IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Purolator;
        }
        
    }
}