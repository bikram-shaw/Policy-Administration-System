using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesService.Models;
using QuotesService.Service;

namespace QuotesService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService service;

        public QuotesController(IQuotesService service)
        {
            this.service = service;
        }

        [HttpGet("{businessValue}/{propertyValue}/{propertyType}")]
        public IActionResult getQuotesForPolicy(long businessValue,long propertyValue,string propertyType)
        {
            string quotes= service.GetQuotesForPolicy(businessValue, propertyValue, propertyType);
            if (quotes.Length>0)
                return Ok(new CustomResponse(1,"",quotes));
            return Ok(new CustomResponse(2, "No Quotes, Contact Insurance Provider", null));
        }
    }
}
