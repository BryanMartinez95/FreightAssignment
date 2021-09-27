using System.Collections.Generic;
using System.Xml.Serialization;
using Shared.Models;

namespace Canpar.Models
{
    [XmlRoot("QuoteModel")]
    public class CanparQuoteRequest : IQuoteRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<string> Packages { get; set; }
        
    }
}