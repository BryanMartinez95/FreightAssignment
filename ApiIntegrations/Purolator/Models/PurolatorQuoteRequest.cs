using System.Collections.Generic;
using Shared.Models;

namespace Purolator.Models
{
    public class PurolatorQuoteRequest : IQuoteRequest
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress { get; set; }
        public List<string> PackageDimensions { get; set; }
        
    }
}