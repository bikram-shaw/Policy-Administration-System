using QuotesService.Repository;

namespace QuotesService.Service
{
    public class QuotesServices : IQuotesService
    {
        private readonly IQuotesRepository repository;

        public QuotesServices(IQuotesRepository repository)
        {
            this.repository = repository;
        }

        public string GetQuotesForPolicy(long businessValue, long propertValue, string propertyType)
        {
            return repository.GetQuotes(businessValue,propertValue,propertyType);
        }
    }
}
