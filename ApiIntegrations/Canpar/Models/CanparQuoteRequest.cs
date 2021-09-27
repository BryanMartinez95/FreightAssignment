using System.Collections.Generic;
using Shared.Models;

namespace Canpar.Models
{
    public class CanparQuoteRequest : IQuoteRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<string> Packages { get; set; }
        
    }
}