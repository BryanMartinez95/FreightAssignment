using System.Collections.Generic;
using Fedex.Models;
using Fedex.Services;
using Models.ApiIntegration;
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

        [TestFixture]
        public class ConvertRequestTests : FedexQuoteIntegrationServiceTests
        {
            private QuoteModel _quoteModel;
            [OneTimeSetUp]
            public void SetUpFixture()
            {
                _quoteModel= new QuoteModel
                {
                    SourceAddress = "123 abc street",
                    DestinationAddress = "456 cbc street",
                    Cartons = new List<string>
                    {
                        "Package 1",
                        "Package 2"
                    }
                };
            }
            
            [Test]
            public void TestConvertRequestNoException()
            {
    
                Assert.DoesNotThrow(() => _sut.ConvertRequest(_quoteModel));
            }
            
            [Test]
            public void TestConvertResponseToRateModel()
            {
                var quoteRequest = _sut.ConvertRequest(_quoteModel);
                Assert.NotNull(quoteRequest);
            }
            [Test]
            public void TestConvertResponseMapping()
            {
                FedexQuoteRequest quoteRequest = (FedexQuoteRequest)_sut.ConvertRequest(_quoteModel);
                
                Assert.AreEqual(_quoteModel.SourceAddress, quoteRequest.Consignee);
                Assert.AreEqual(_quoteModel.DestinationAddress, quoteRequest.Consignor);
                Assert.AreEqual(_quoteModel.Cartons.Count, quoteRequest.Cartons.Count);
            }   

        }
        
        [TestFixture]
        public class ConvertResponseTests : FedexQuoteIntegrationServiceTests
        {
            private FedexRateResponse _rateResponse;
            [OneTimeSetUp]
            public void SetUpFixture()
            {
                _rateResponse = new FedexRateResponse
                {
                    Amount = 10
                };
            }
            
            [Test]
            public void TestConvertResponseNoException()
            {
                Assert.DoesNotThrow(() => _sut.ConvertResponse(_rateResponse));
            }       
            
            
            [Test]
            public void TestConvertResponseToRateModel()
            {
                var rateModel = _sut.ConvertResponse(_rateResponse);
                Assert.NotNull(rateModel);
            }
            [Test]
            public void TestConvertResponseMapping()
            {
                var rateModel = _sut.ConvertResponse(_rateResponse);
                Assert.AreEqual(_rateResponse.Amount, rateModel.Rate);
                Assert.AreEqual(IntegrationPartner.Fedex.ToString(), rateModel.Name);
            }   
            
        }
    }
}