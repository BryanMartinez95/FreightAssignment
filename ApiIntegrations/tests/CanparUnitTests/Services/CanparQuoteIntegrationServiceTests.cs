using System.Collections.Generic;
using Canpar.Models;
using Canpar.Services;
using Models.ApiIntegration;
using Models.Quote;
using NUnit.Framework;

namespace CanparUnitTests.Services
{
    [TestFixture]
    public class CanparQuoteIntegrationServiceTests
    {
        private CanparQuoteIntegrationService _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new CanparQuoteIntegrationService();

        }

        [TestFixture]
        public class ConvertRequestTests : CanparQuoteIntegrationServiceTests
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
                CanparQuoteRequest quoteRequest = (CanparQuoteRequest)_sut.ConvertRequest(_quoteModel);
                
                Assert.AreEqual(_quoteModel.SourceAddress, quoteRequest.Source);
                Assert.AreEqual(_quoteModel.DestinationAddress, quoteRequest.Destination);
                Assert.AreEqual(_quoteModel.Cartons.Count, quoteRequest.Packages.Count);
            }   
        }


        [TestFixture]
        public class ConvertResponseTests : CanparQuoteIntegrationServiceTests
        {
            private CanparRateResponse _rateResponse;
            [OneTimeSetUp]
            public void SetUpFixture()
            {
                _rateResponse = new CanparRateResponse
                {
                    Quote = 10
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
                 Assert.AreEqual(_rateResponse.Quote, rateModel.Rate);
                 Assert.AreEqual(IntegrationPartner.Canpar.ToString(), rateModel.Name);
             }   
        }
    }
}