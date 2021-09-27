using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Quote
{
    public class QuoteModel
    {
        [Required]
        public string SourceAddress { get; set; }
        
        [Required]
        public string DestinationAddress { get; set; }
        public List<string> Cartons { get; set; }
    }
}