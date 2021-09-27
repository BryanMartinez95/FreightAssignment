using System.Collections.Generic;
using Models.ApiIntegration;
using Models.Quote;
using NUnit.Framework;
using Purolator.Models;
using Purolator.Services;

namespace PurolatorUnitTests.Services
{
    public class PurolatorQuoteIntegrationServiceTests
    {
        private PurolatorQuoteIntegrationService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new PurolatorQuoteIntegrationService();

        }

        [TestFixture]
        public class ConvertRequestTests : PurolatorQuoteIntegrationServiceTests
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
                PurolatorQuoteRequest quoteRequest = (PurolatorQuoteRequest)_sut.ConvertRequest(_quoteModel);
                
                Assert.AreEqual(_quoteModel.SourceAddress, quoteRequest.WarehouseAddress);
                Assert.AreEqual(_quoteModel.DestinationAddress, quoteRequest.ContactAddress);
                Assert.AreEqual(_quoteModel.Cartons.Count, quoteRequest.PackageDimensions.Count);
            }   

        }
        
        [TestFixture]
        public class ConvertResponseTests : PurolatorQuoteIntegrationServiceTests
        {
            private PurolatorRateResponse _rateResponse;
            [OneTimeSetUp]
            public void SetUpFixture()
            {
                _rateResponse = new PurolatorRateResponse
                {
                    Total = 10
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
                Assert.AreEqual(_rateResponse.Total, rateModel.Rate);
                Assert.AreEqual(IntegrationPartner.Purolator.ToString(), rateModel.Name);
            }   
            
        }
    }
}