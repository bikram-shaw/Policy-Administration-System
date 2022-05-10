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

        [HttpGet("{PId}/{CustId}")]
        public IActionResult IssuePolicy(long PId, long CustId)
        {
            bool status=service.IssuePolicy(PId,CustId);
            if (status)
            {
                return Ok(new CustomResponse(200, "Policy has been issued.", null));
            }
            return BadRequest(new CustomResponse(400, "Not Found any policy!", null));
        }
        [HttpGet("{Pid}")]
        public IActionResult GetPolicy(string Pid)
        {
            PolicyMasterModel policyMasterModel = service.GetPolicy(Pid);
            if (policyMasterModel!=null)
            {
                return Ok(policyMasterModel);
            }
            return BadRequest(new CustomResponse(400,"Not Found!",null));
        }
    }
}
