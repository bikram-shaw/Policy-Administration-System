using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PolicyService.Data.Entities;
using PolicyService.Models;
using PolicyService.Repository;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PolicyService.Service
{
    public class ConsumerPolicyService : IConsumerPolicyService
    {
        private readonly IConsumerPolicyRepository consumerPolicyRepository;
        private IConfiguration configuration;
        private readonly IPolicyMasterRepository policyMasterRepository;
        private string token;
        private PolicyMaster policyMaster = null;

        public ConsumerPolicyService(IConsumerPolicyRepository consumerPolicyRepository, IConfiguration _configuration, IPolicyMasterRepository policyMasterRepository)
        {
            this.consumerPolicyRepository = consumerPolicyRepository;
            configuration = _configuration;
            this.policyMasterRepository = policyMasterRepository;
        }

        public bool CreateConsumerPolicy(CreatePolicyModel createPolicyModel,string token)
        {
            this.token = token;
           
            ConsumerDetailsModel consumerDetails = GetConsumerDetails(createPolicyModel.Cid);
            if (consumerDetails == null)
            {
                return false;
            }
            else
            {
                string quotes=CheckPolicy(consumerDetails);
                if (!string.IsNullOrEmpty(quotes))
                {
                    ConsumerPolicy consumerPolicy = new ConsumerPolicy()
                    {
                        Pid = createPolicyModel.Pid,
                        AcceptedQuote = quotes,
                        AssuredSum = policyMaster.AssuredSum.ToString(),
                        BaseLocation = policyMaster.BaseLocation,
                       BusinessValue = consumerDetails.BusinessDetails.BusinessValue,
                        ConsumerId = createPolicyModel.Cid,
                        ConsumerType = policyMaster.ConsumerType,
                        PropertyType = policyMaster.PropertyType,
                        PropertyValue = consumerDetails.BusinessDetails.PropertyDetails[0].PropertyValue,
                        Tenure = policyMaster.Tenure,
                        Status = "Initiated"
                    };
                    return consumerPolicyRepository.CreateConsumerPolicy(consumerPolicy);
                }
            }
           return false;
        }

        public ConsumerPolicyModel GetPolicy(string cId)
        {
            ConsumerPolicy consumerPolicy = consumerPolicyRepository.GetPolicy(cId);
            if (consumerPolicy == null)
            {
                return null;
            }
            return new ConsumerPolicyModel()
            {
                Id=consumerPolicy.Id,
                AcceptedQuote=consumerPolicy.AcceptedQuote,
                AssuredSum=consumerPolicy.AssuredSum,
                BaseLocation=consumerPolicy.BaseLocation,
                ConsumerType=consumerPolicy.ConsumerType,
                PropertyType=consumerPolicy.PropertyType,
                Type=consumerPolicy.Type,
                Status=consumerPolicy.Status,
                Tenure=consumerPolicy.Tenure,
                Pid=consumerPolicy.Pid
            };
        }

        public bool IssuePolicy(string PId, long CustId)
        {
            return consumerPolicyRepository.IssuePolicy(PId,CustId);
        }

        private string CheckPolicy(ConsumerDetailsModel consumerDetails)
        {
            string check = string.Empty ;
            PropertyDetailsModel pd = consumerDetails.BusinessDetails.PropertyDetails[0];
                 policyMaster =policyMasterRepository.GetPolicyMaster(consumerDetails.BusinessDetails.BusinessValue, pd.PropertyValue);
                if (policyMaster != null)
                {
                    string quotes = GetQuotes(consumerDetails.BusinessDetails.BusinessValue, pd.PropertyValue,pd.PropertyType);
                    
                    if (!string.IsNullOrEmpty(quotes))
                    {
                        return quotes;
                    }
                }
           
            return string.Empty;
        }

         private ConsumerDetailsModel GetConsumerDetails(long consumerId)
        {
            string consumerBaseUrl = configuration.GetValue<string>("ApiUrls:consumerApi");
           
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(consumerBaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization",token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
              
                try
                {
                    response = client.GetAsync("api/ConsumerBusiness/ViewConsumerBusiness/"+consumerId).Result;
                }
                catch (Exception e)
                {
                   

                    response = null;

                }

                if
                    (response != null)
                {
                   

                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    CustomResponse res = JsonConvert.DeserializeObject<CustomResponse>(ObjResponse);
                    return JsonConvert.DeserializeObject<ConsumerDetailsModel>(ObjResponse);
                }
                return null;

            }
        }
        private string GetQuotes(long businessValue, long propertyValue,string propertyType)
        {
            string quotesBaseUrl = configuration.GetValue<string>("ApiUrls:quotesAPi");
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(quotesBaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization",token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    response = client.GetAsync("api/Quotes/getQuotesForPolicy/" + businessValue+"/"+ propertyValue+"/"+ propertyType).Result;
                }
                catch (Exception e)
                {


                    response = null;

                }

                if
                    (response != null)
                {


                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    CustomResponse res = JsonConvert.DeserializeObject<CustomResponse>(ObjResponse);
                    if (res.data == null)
                    {
                        return null;
                    }
                    string quotes = JsonConvert.DeserializeObject<string>(res.data.ToString());
                    return quotes;
                }
                return null;

            }
        }
    }
}
