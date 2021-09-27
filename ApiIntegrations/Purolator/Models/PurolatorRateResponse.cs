using Shared.Models;

namespace Purolator.Models
{
    public class PurolatorRateResponse : IRateResponse
    {
        public double Total { get; set; }
    }
}