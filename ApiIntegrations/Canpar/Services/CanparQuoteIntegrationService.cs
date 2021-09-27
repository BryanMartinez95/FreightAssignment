using System;
using System.Threading.Tasks;
using Canpar.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Xml;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Shared.Models;
using Shared.Services;

namespace Canpar.Services
{
    public class CanparQuoteIntegrationService: QuoteIntegrationService
    {
        private string baseUrl = "http://localhost:7011";

        protected override async Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest)
        {
            return await baseUrl
                .AppendPathSegment("quote")
                .AppendPathSegment("quote")
                .PostXmlAsync(quoteRequest)
                .ReceiveXml<CanparRateResponse>();
        }

        public override IQuoteRequest ConvertRequest(QuoteModel quoteModel)
        {
            return new CanparQuoteRequest
            {
                Source = quoteModel.SourceAddress,
                Destination = quoteModel.DestinationAddress,
                Packages = quoteModel.Cartons
            };
        }

        public override RateModel ConvertResponse(IRateResponse response)
        {
            var canparResponse = (CanparRateResponse)response;
            
            return new RateModel
            {
                Name = GetIntegrationPartner().ToString(),
                Rate = canparResponse.Quote
            };
        }

        protected override IntegrationPartner GetIntegrationPartner()
        {
            return IntegrationPartner.Canpar;
        }
    }
}