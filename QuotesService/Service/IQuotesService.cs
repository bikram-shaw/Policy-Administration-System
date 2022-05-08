using Microsoft.AspNetCore.Mvc;

namespace QuotesService.Service
{
    public interface IQuotesService
    {
        string GetQuotesForPolicy(long businessValue, long propertValue, string propertyType);
    }
}
