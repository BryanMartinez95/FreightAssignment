using System;
using System.Collections.Generic;
using Autofac;
using Base.Resolvers;
using Canpar.Services;
using Models.ApiIntegration;
using Shared.Models;
using Shared.Services;

namespace Shared.Resolvers
{
    public class QuoteIntegrationResolver : IQuoteIntegrationResolver
    {
        private readonly Dictionary<IntegrationPartner, Type> _dictionary;
        private readonly IComponentContext _serviceProvider;
        
        public QuoteIntegrationResolver(IComponentContext serviceProvider)
        {
            _serviceProvider = serviceProvider; 
            _dictionary =  new Dictionary<IntegrationPartner,Type> { { IntegrationPartner.Canpar, typeof(CanparQuoteIntegrationService) } };
        }

        public IQuoteIntegrationService<IQuoteRequest,IQuoteResponse> Resolve(IntegrationPartner partner)
        {
            return (IQuoteIntegrationService<IQuoteRequest,IQuoteResponse>)_serviceProvider.Resolve(_dictionary[partner]);
        }
        
    }
}