using ConsumerService.Models;
using ConsumerService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessPropertyController : ControllerBase
    {
        private readonly IBusinessPropertyService businessPropertyService;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BusinessPropertyController));

        public BusinessPropertyController(IBusinessPropertyService service)
        {
            this.businessPropertyService = service;
        }

      /// <summary>
      /// create business prperty
      /// </summary>
      /// <param name="propertyDetailsModel"></param>
      /// <returns></returns>

        [HttpPost]
        public IActionResult CreateBusinessProperty(PropertyDetailsModel propertyDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _log4net.Info("Create business started");
                if (businessPropertyService.CreateBusinessProperty(propertyDetailsModel))
                {
                    return Ok(new CustomResponse(Enums.ResponseCode.Ok, "Business property has been created.",null));
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// update business property
        /// </summary>
        /// <param name="propertyId"></param>
        /// <param name="propertyDetailsModel"></param>
        /// <returns></returns>
        [HttpPut("{propertyId}")]
        public IActionResult UpdateBusinessProperty(long propertyId, PropertyDetailsModel propertyDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _log4net.Info(" update business started");
                if (businessPropertyService.UpdateBusinessProperty(propertyId,propertyDetailsModel))
                {
                    return Ok(new CustomResponse(Enums.ResponseCode.Ok, "Business property has been updated.", null));
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// get consumer property
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpGet("{businessId}")]
        public IActionResult ViewConsumerProperty(long businessId)
        {
            _log4net.Info("view consumer started");
            return Ok(new CustomResponse(Enums.ResponseCode.Ok, "", businessPropertyService.GetBusinessProperty(businessId)));
        }
    }
}
