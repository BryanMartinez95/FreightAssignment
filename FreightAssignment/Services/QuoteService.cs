﻿using System;
using System.Collections.Generic;
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
        
        public async Task<List<RateModel>> GetRates(QuoteModel quoteModel)
        {
            quoteModel = new QuoteModel
            {
                SourceAddress = "123 abc street",
                DestinationAddress = "456 cbc street",
                Cartons = new List<CartonModel>
                {
                    new CartonModel { Height = 100, Length = 100, Width = 100, Weight = 100 },
                    new CartonModel { Height = 200, Length = 200, Width = 200, Weight = 200 }
                }
            };

            var rates = new List<RateModel>();
            
            foreach (var partner in Enum.GetValues(typeof(IntegrationPartner)))
            {
                var service = _quoteIntegrationFactory.Resolve((IntegrationPartner)partner);
                rates.Add(await service.GetRate(quoteModel));
            }

            return rates;
        }
        public async Task<RateModel> GetRate(IntegrationPartner partner,QuoteModel quoteModel)
        {
            quoteModel = new QuoteModel
            {
                SourceAddress = "123 abc street",
                DestinationAddress = "456 cbc street",
                Cartons = new List<CartonModel>
                {
                    new CartonModel { Height = 100, Length = 100, Width = 100, Weight = 100 },
                    new CartonModel { Height = 200, Length = 200, Width = 200, Weight = 200 }
                }
            };
            
            var service = _quoteIntegrationFactory.Resolve(partner);
            return await service.GetRate(quoteModel);
        }
    }

}