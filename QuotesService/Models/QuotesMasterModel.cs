namespace QuotesService.Models
{
    public class QuotesMasterModel
    {
        public long Id { get; set; }
        public long BusinessValue { get; set; }
        public long PropertyValue { get; set; }
        public string PropertyType { get; set; }
        public string Quotes { get; set; }
    }
}
