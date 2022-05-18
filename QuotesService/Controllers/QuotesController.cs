using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesService.Models;
using QuotesService.Service;

namespace QuotesService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService quotesService;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesController));
        public QuotesController(IQuotesService service)
        {
            
            this.quotesService = service;
        }

        /// <summary>
        /// get quotes  for policy
        /// </summary>
        /// <param name="businessValue"></param>
        /// <param name="propertyValue"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
   
        [HttpGet("{businessValue}/{propertyValue}/{propertyType}")]
        public IActionResult getQuotesForPolicy(long businessValue,long propertyValue,string propertyType)
        {
            string quotes= quotesService.GetQuotesForPolicy(businessValue, propertyValue, propertyType);
            if (quotes.Length>0)
                return Ok(new CustomResponse(1,"",quotes));
            return Ok(new CustomResponse(2, "No Quotes, Contact Insurance Provider", null));
        }
    }
}
