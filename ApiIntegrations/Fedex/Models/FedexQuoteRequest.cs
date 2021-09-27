using System.Collections.Generic;
using Shared.Models;

namespace Fedex.Models
{
    public class FedexQuoteRequest: IQuoteRequest
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public List<string> Cartons { get; set; }
    }
}