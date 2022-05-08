using QuotesService.Data;
using QuotesService.Data.Entities;
using System.Linq;

namespace QuotesService.Repository
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly QuotesServiceContext context;

        public QuotesRepository(QuotesServiceContext  context)
        {
            this.context = context;
        }

        public string GetQuotes(long businessValue, long propertValue, string propertyType)
        {
            QuotesMaster quotesMaster= context.QuotesMaster.Where(q => q.BusinessValue == businessValue && q.PropertyValue == propertValue && q.PropertyType == propertyType).FirstOrDefault();
            if(quotesMaster != null)
            {
                return quotesMaster.Quotes;
            }
            return string.Empty;
        }
    }
}
