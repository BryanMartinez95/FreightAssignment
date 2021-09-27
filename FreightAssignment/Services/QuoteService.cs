using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Factories;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;

namespace FreightAssignment.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteIntegrationFactory _quoteIntegrationFactory;
        public QuoteService(IQuoteIntegrationFactory quoteIntegrationFactory)
        {
            _quoteIntegrationFactory = quoteIntegrationFactory;
        }
        
        public async Task<RateModel> QuotePartners(QuoteModel quoteModel)
        {
            var rates = new List<RateModel>();
            
            foreach (var partner in Enum.GetValues(typeof(IntegrationPartner)))
            {
                var service = _quoteIntegrationFactory.Resolve((IntegrationPartner)partner);
                
                RateModel rate = await service.GetRate(quoteModel);
                
                if (rate != null)
                {
                    rates.Add(rate);    
                }
                
            }
            
            return GetCheapestRate(rates);
        }
        public async Task<RateModel> QuotePartner(IntegrationPartner partner,QuoteModel quoteModel)
        {
            var service = _quoteIntegrationFactory.Resolve(partner);
            return await service.GetRate(quoteModel);
        }

        public RateModel GetCheapestRate(List<RateModel> rates)
        {
            if (rates == null || !rates.Any())
            {
                return new RateModel
                {
                    Name = "N/A",
                    Rate = 0
                };
            }
            
            return rates.OrderBy(x => x.Rate).FirstOrDefault();
        }
    }

}