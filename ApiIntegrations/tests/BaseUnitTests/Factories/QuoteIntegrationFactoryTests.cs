using System;
using Base.Factories;
using Canpar.Services;
using Models.ApiIntegration;
using NUnit.Framework;

namespace BaseUnitTests.Factories
{
    public class QuoteIntegrationFactoryTests
    {
        private QuoteIntegrationFactory _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new QuoteIntegrationFactory();
        }

        [Test]
        public void CheckIntegratedPartners()
        {
            foreach (var partner in Enum.GetValues(typeof(IntegrationPartner)))
            {
                Assert.DoesNotThrow(() => _sut.Resolve((IntegrationPartner)partner));
            }
            
        }
    }
}