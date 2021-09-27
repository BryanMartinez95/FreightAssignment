using Shared.Models;

namespace Canpar.Models
{
    public class CanparRateResponse: IRateResponse
    {
        public double Quote { get; set; }
    }
}