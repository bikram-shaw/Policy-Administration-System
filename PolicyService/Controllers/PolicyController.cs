using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PolicyService.Models;
using PolicyService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IConsumerPolicyService service;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        public PolicyController(IConsumerPolicyService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreatePolicy(ConsumerPolicyModel consumerPolicyModel)
        {
            if (ModelState.IsValid)
            {
                _log4net.Info("Create Policy started");

                var accessToken = Request.Headers[HeaderNames.Authorization];
                if (service.CreateConsumerPolicy(consumerPolicyModel, accessToken))
                {
                    return Ok(new CustomResponse(201,"Policy has been created successfully.",null));
                }
            }
            return BadRequest(new CustomResponse(400, "Not Eligible.", null));
        }

        [HttpGet("{PId}/{CustId}")]
        public IActionResult IssuePolicy(long PId, long CustId)
        {
            _log4net.Info("Issue policy started");

            bool status=service.IssuePolicy(PId,CustId);
            if (status)
            {
                return Ok(new CustomResponse(200, "Policy successfully issued.", null));
            }
            return BadRequest(new CustomResponse(400, "Not Found any policy!", null));
        }
        [HttpGet("{Pid}")]
        public IActionResult GetPolicy(string Pid)
        {
            _log4net.Info("Get policy started");

            PolicyMasterModel policyMasterModel = service.GetPolicy(Pid);

            if (policyMasterModel!=null)
            {
                return Ok(policyMasterModel);
            }
            return BadRequest(new CustomResponse(400,"Not Found!",null));
        }
    }
}
