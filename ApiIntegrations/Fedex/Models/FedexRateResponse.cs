using Shared.Models;

namespace Fedex.Models
{
    public class FedexRateResponse : IRateResponse
    {
        public double Amount { get; set; }
    }
}