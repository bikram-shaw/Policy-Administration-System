namespace QuotesService.Repository
{
    public interface IQuotesRepository
    {
        string GetQuotes(long businessValue, long propertValue, string propertyType);
    }
}
