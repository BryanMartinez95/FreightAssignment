using System.Collections.Generic;
using Fedex.Models;
using Fedex.Services;
using Models.Quote;
using NUnit.Framework;

namespace FedexUnitTests.Services
{
    public class FedexQuoteIntegrationServiceTests
    {
        private FedexQuoteIntegrationService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new FedexQuoteIntegrationService();

        }

        [Test]
        public void TestConvertRequestNoException()
        {
            var quoteModel = new QuoteModel
            {
                SourceAddress = "123 abc street",
                DestinationAddress = "456 cbc street",
                Cartons = new List<string>
                {
                    "Package 1",
                    "Package 2"
                }
            };
            Assert.DoesNotThrow(() => _sut.ConvertRequest(quoteModel));
        }
        
        [Test]
        public void TestConvertResponseNoException()
        {
            var rateResponse = new FedexRateResponse
            {
                Amount = 10
            };
            Assert.DoesNotThrow(() => _sut.ConvertResponse(rateResponse));
        }
    }
}