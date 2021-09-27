using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Factories;
using FreightAssignment.Services;
using Models.ApiIntegration;
using Models.Quote;
using Models.Rate;
using Moq;
using NUnit.Framework;
using Shared.Services;

namespace FreightAssignmentTests.Integration.Services
{
    [TestFixture]
    public class QuoteServiceIntegrationTests
    {
        public class QuoteServiceTests
        {
            private QuoteService _sut;
            private QuoteModel _quoteModel;
            
            private RateModel _lowRate;
            private RateModel _noRate;

            
            [SetUp]
            public void Setup()
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
                
                _lowRate = new RateModel
                {
                    Name = IntegrationPartner.Canpar.ToString(),
                    Rate = 10
                };
                
                _noRate = null;

            }
    
            [Test]
            public async Task QuotePartners_AvailableRateTest()
            {
                var firstTime = true;
                var quoteIntegrationFactoryMock = new Mock<IQuoteIntegrationFactory>();
                var mockPartner1 = new Mock<QuoteIntegrationService>();
                var mockPartner2 = new Mock<QuoteIntegrationService>();
                
                //Partner 1 does not have an available rate
                mockPartner1.Setup(repo => repo.GetRate(_quoteModel)).ReturnsAsync(_noRate);
                
                //Partner 2 does have available rates
                mockPartner2.Setup(repo => repo.GetRate(_quoteModel)).ReturnsAsync(_lowRate);
                
                quoteIntegrationFactoryMock.Setup(x => x.Resolve(It.IsAny<IntegrationPartner>()))
                    .Returns(()=>
                    {
                        if(!firstTime)
                            return mockPartner1.Object;

                        firstTime = false;
                        return mockPartner2.Object;
                    });

                _sut = new QuoteService(quoteIntegrationFactoryMock.Object);
                
                
                RateModel rate =await _sut.QuotePartners(_quoteModel);
                Assert.AreEqual(_lowRate,rate);
                Assert.AreEqual(_lowRate.Rate,rate.Rate);
                
            }
            
            [Test]
            public async Task QuotePartners_NoRatesTest()
            {
                var quoteIntegrationFactoryMock = new Mock<IQuoteIntegrationFactory>();
                var mockPartner1 = new Mock<QuoteIntegrationService>();

                //Assume all API's are returning null
                mockPartner1.Setup(repo => repo.GetRate(_quoteModel)).ReturnsAsync(_noRate);

                //force the factory to use mockPartner1
                quoteIntegrationFactoryMock.Setup(x => x.Resolve(It.IsAny<IntegrationPartner>())).Returns(mockPartner1.Object);

                _sut = new QuoteService(quoteIntegrationFactoryMock.Object);
                
                
                RateModel rate =await _sut.QuotePartners(_quoteModel);
                Assert.AreEqual("N/A",rate.Name);
                Assert.AreEqual(0,rate.Rate);
                
            }
            

            
            
        }
    }
}