using System.Collections.Generic;
using Canpar.Models;
using Canpar.Services;
using Models.Quote;
using NUnit.Framework;

namespace CanparUnitTests.Services
{
    public class CanparQuoteIntegrationServiceTests
    {
        private CanparQuoteIntegrationService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new CanparQuoteIntegrationService();

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
            var rateResponse = new CanparRateResponse
            {
                Quote = 10
            };
            Assert.DoesNotThrow(() => _sut.ConvertResponse(rateResponse));
        }
    }
}