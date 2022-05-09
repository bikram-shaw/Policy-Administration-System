using ConsumerService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsumerService.Models;
using ConsumerService.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ConsumerService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class ConsumerBusinessController : ControllerBase
    {
        private readonly IConsumerBusinessService service;

        public ConsumerBusinessController(IConsumerBusinessService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Create Consumer With Business
        /// </summary>
        /// <param name="consumerBusinessModal"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateConsumerBusiness(ConsumerDetailsModel consumerBusinessModal)
        {
            if (ModelState.IsValid)
            {
                if (service.CreateConsumer(consumerBusinessModal))
                {
                    return Created("",new CustomResponse(ResponseCode.Ok, "Consumer business has been created", null));
                }

            }
            return BadRequest();
        }

        /// <summary>
        /// View Consumer Business
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns></returns>

        [HttpGet("{consumerId}")]
        public IActionResult ViewConsumerBusiness(long consumerId)
        {
            var ConsumerBusiness = service.GetConsumerDetails(consumerId);
            if (ConsumerBusiness != null)
            {
                return Ok( ConsumerBusiness);
            }
            return NotFound(new CustomResponse(ResponseCode.Error, "Consumer with id "+consumerId+" not found!", null));
        }

        /// <summary>
        /// Update Consumer
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="consumerDetailsModel"></param>
        /// <returns></returns>
        [HttpPut("{consumerId}")]
        public IActionResult UpdateConsumerBusiness(long consumerId,ConsumerDetailsModel consumerDetailsModel)
        {
            if (ModelState.IsValid) { 
              if(service.UpdateConsumer(consumerId, consumerDetailsModel))
                {
                    return Ok(new CustomResponse(ResponseCode.Ok, "Consumer details has been updated.", null));
                }
            }
            return BadRequest(new CustomResponse(ResponseCode.Error, "Something went wrong!", null));
        }
    }
}
