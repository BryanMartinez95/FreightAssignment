using System;
using System.Threading.Tasks;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Shared.Models;

namespace Shared.Services
{
    public abstract class QuoteIntegrationService
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        protected abstract IntegrationPartner GetIntegrationPartner();
        public virtual async Task<RateModel> GetRate(QuoteModel quoteModel)
        {
            try
            {
                var quoteRequest = ConvertRequest(quoteModel);
                Logger.Info($"{GetIntegrationPartner()} Sending Request");
                var rateResponse = await SendRequest(quoteRequest);
                Logger.Info($"{GetIntegrationPartner()} Finish Request");
                return ConvertResponse(rateResponse);
            }
            catch (Exception e)
            {
                Logger.Error($"{GetIntegrationPartner()} REQUEST FAILED - {e.Message}");
                return null;
            }
        }

        public abstract IQuoteRequest ConvertRequest(QuoteModel quoteModel);
        public abstract RateModel ConvertResponse(IRateResponse response);
        protected abstract Task<IRateResponse> SendRequest(IQuoteRequest quoteRequest);
    }
}