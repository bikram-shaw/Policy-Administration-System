using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyService.Models;
using PolicyService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IConsumerPolicyService service;

        public PolicyController(IConsumerPolicyService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult CreatePolicy(ConsumerPolicyModel consumerPolicyModel)
        {
            if (ModelState.IsValid)
            {
                if (service.CreateConsumerPolicy(consumerPolicyModel))
                {
                    return Ok(new CustomResponse(201,"Policy has been created successfully.",null));
                }
            }
            return BadRequest(new CustomResponse(400, "Not Eligible.", null));
        }
    }
}
