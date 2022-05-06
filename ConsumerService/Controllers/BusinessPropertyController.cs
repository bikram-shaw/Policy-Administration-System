using ConsumerService.Models;
using ConsumerService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessPropertyController : ControllerBase
    {
        private readonly IBusinessPropertyService service;

        public BusinessPropertyController(IBusinessPropertyService service)
        {
            this.service = service;
        }

      

        [HttpPost]
        public IActionResult CreateBusinessProperty(PropertyDetailsModel propertyDetailsModel)
        {
            if (ModelState.IsValid)
            {
                if (service.CreateBusinessProperty(propertyDetailsModel))
                {
                    return Ok(new CustomResponse(Enums.ResponseCode.Ok, "Business property has been created.",null));
                }
            }
            return BadRequest();
        }

        [HttpPut("{propertyId}")]
        public IActionResult UpdateBusinessProperty(long propertyId, PropertyDetailsModel propertyDetailsModel)
        {
            if (ModelState.IsValid)
            {
                if (service.UpdateBusinessProperty(propertyId,propertyDetailsModel))
                {
                    return Ok(new CustomResponse(Enums.ResponseCode.Ok, "Business property has been updated.", null));
                }
            }
            return BadRequest();
        }

        [HttpGet("businessId")]
        public IActionResult ViewConsumerProperty(long businessId)
        {
            return Ok(new CustomResponse(Enums.ResponseCode.Ok, "", service.GetBusinessProperty(businessId)));
        }
    }
}
