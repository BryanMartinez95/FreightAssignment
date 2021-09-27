using System.Collections.Generic;
using Base.Factories;
using FreightAssignment.Services;
using Models.ApiIntegration;
using Models.Rate;
using NUnit.Framework;

namespace FreightAssignmentTests.Unit.Services
{
    [TestFixture]
    public class QuoteServiceTests
    {
        private QuoteService _sut;
        private RateModel _lowRate;
        private RateModel _mediumRate;
        private RateModel _highRate;
        
        [SetUp]
        public void Setup()
        {
            QuoteIntegrationFactory quoteIntegrationFactory = new QuoteIntegrationFactory();
            _sut = new QuoteService(quoteIntegrationFactory);

            _lowRate = new RateModel
            {
                Name = IntegrationPartner.Canpar.ToString(),
                Rate = 10
            };
            
            _mediumRate = new RateModel
            {
                Name = IntegrationPartner.Fedex.ToString(),
                Rate = 20
            };
            
            _highRate = new RateModel
            {
                Name = IntegrationPartner.Purolator.ToString(),
                Rate = 30
            };

        }

        [Test]
        public void GetCheapestRateTest()
        {
            var rates = new List<RateModel>();
            rates.Add(_lowRate);
            rates.Add(_mediumRate);
            rates.Add(_highRate);
            
            var rate = _sut.GetCheapestRate(rates);
            
            Assert.AreEqual(_lowRate.Rate,rate.Rate);
            Assert.AreEqual(_lowRate.Name,rate.Name);
        }
        
        [Test]
        public void GetCheapestRate_NoRatesTest()
        {
            var rates = new List<RateModel>();

            var rate = _sut.GetCheapestRate(rates);
            
            Assert.AreEqual(0,rate.Rate);
            Assert.AreEqual("N/A",rate.Name);
        }
        
        [Test]
        public void GetCheapestRate_NullRatesTest()
        {
            List<RateModel> rates = null;

            var rate = _sut.GetCheapestRate(rates);
            
            Assert.AreEqual(0,rate.Rate);
            Assert.AreEqual("N/A",rate.Name);
        }
        
        
    }
}