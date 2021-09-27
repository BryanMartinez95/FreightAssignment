using System.Collections.Generic;
using Models.Quote;
using NUnit.Framework;
using Purolator.Models;
using Purolator.Services;

namespace PurolatorUnitTests.Services
{
    public class PurolatorIntegrationServiceTests
    {
        private PurolatorQuoteIntegrationService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new PurolatorQuoteIntegrationService();

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
            var rateResponse = new PurolatorRateResponse
            {
                Total = 10
            };
            Assert.DoesNotThrow(() => _sut.ConvertResponse(rateResponse));
        }
    }
}