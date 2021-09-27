using System.Xml.Serialization;
using Shared.Models;

namespace Canpar.Models
{
    [XmlRoot("RateModel")]
    public class CanparRateResponse: IRateResponse
    {
        public double Quote { get; set; }
    }
}