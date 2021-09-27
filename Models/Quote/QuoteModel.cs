using System.Collections.Generic;

namespace Models.Quote
{
    public class QuoteModel
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public List<string> Cartons { get; set; }
    }
}