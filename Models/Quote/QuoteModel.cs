using System.Collections.Generic;

namespace Models.Quote
{
    public class QuoteModel
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public List<CartonModel> Cartons { get; set; }
    }
}