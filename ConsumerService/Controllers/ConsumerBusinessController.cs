using ConsumerService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsumerService.Models;
using ConsumerService.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace ConsumerService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
   
    public class ConsumerBusinessController : ControllerBase
    {
        private readonly IConsumerBusinessService consumerBusinessService;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerBusinessController));
        public ConsumerBusinessController(IConsumerBusinessService service)
        {
            this.consumerBusinessService = service;
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
                _log4net.Info("Create consumer started");

                if (consumerBusinessService.CreateConsumer(consumerBusinessModal))
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
            _log4net.Info("View consumer started");
            var ConsumerBusiness = consumerBusinessService.GetConsumerDetails(consumerId);
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

                _log4net.Info("update consumer started");

                if (consumerBusinessService.UpdateConsumer(consumerId, consumerDetailsModel))
                {
                    return Ok(new CustomResponse(ResponseCode.Ok, "Consumer details has been updated.", null));
                }
            }
            return BadRequest(new CustomResponse(ResponseCode.Error, "Something went wrong!", null));
        }
    }
}
