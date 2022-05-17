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

        public ConsumerPolicyService(IConsumerPolicyRepository consumerPolicyRepository, IConfiguration _configuration, IPolicyMasterRepository policyMasterRepository)
        {
            this.consumerPolicyRepository = consumerPolicyRepository;
            configuration = _configuration;
            this.policyMasterRepository = policyMasterRepository;
        }

        public bool CreateConsumerPolicy(ConsumerPolicyModel consumerPolicyModel,string token)
        {
            this.token = token;
           
            ConsumerDetailsModel consumerDetails = GetConsumerDetails(consumerPolicyModel.ConsumerId);
            if (consumerDetails == null)
            {
                return false;
            }
            else
            {
                bool eligible=CheckPolicy(consumerDetails);
                if (eligible)
                {
                    ConsumerPolicy consumerPolicy = new ConsumerPolicy()
                    {
                        Pid = consumerPolicyModel.Pid,
                        AcceptedQuote = consumerPolicyModel.AcceptedQuote,
                        AssuredSum = consumerPolicyModel.AssuredSum,
                        BaseLocation = consumerPolicyModel.BaseLocation,
                       BusinessValue = consumerDetails.BusinessDetails.BusinessValue,
                        ConsumerId = consumerPolicyModel.ConsumerId,
                        ConsumerType = consumerPolicyModel.ConsumerType,
                        PropertyType = consumerPolicyModel.PropertyType,
                        PropertyValue = consumerDetails.BusinessDetails.PropertyDetails[0].PropertyValue,
                        Tenure = consumerPolicyModel.Tenure,
                        Status = "Initiated"
                    };
                    return consumerPolicyRepository.CreateConsumerPolicy(consumerPolicy);
                }
            }
           return false;
        }

        public PolicyMasterModel GetPolicy(string PId)
        {
            PolicyMaster policyMaster = consumerPolicyRepository.GetPolicy(PId);
            if (policyMaster == null)
            {
                return null;
            }
            return new PolicyMasterModel()
            {
                Id=policyMaster.Id,
                AssuredSum=policyMaster.AssuredSum,
                BaseLocation=policyMaster.BaseLocation,
                BusinessValue=policyMaster.BusinessValue,
                ConsumerType=policyMaster.ConsumerType,
                PropertyType=policyMaster.PropertyType,
                PropertyValue=policyMaster.PropertyValue,
                Tenure=policyMaster.Tenure,
                Type=policyMaster.Type
            };
        }

        public bool IssuePolicy(long PId, long CustId)
        {
            return consumerPolicyRepository.IssuePolicy(PId,CustId);
        }

        private bool CheckPolicy(ConsumerDetailsModel consumerDetails)
        {
            bool check = false;

            foreach(PropertyDetailsModel pd in consumerDetails.BusinessDetails.PropertyDetails)
            {
                PolicyMaster policyMaster=policyMasterRepository.GetPolicyMaster(consumerDetails.BusinessDetails.BusinessValue,pd.PropertyValue);
                if (policyMaster != null)
                {
                    string quotes = GetQuotes(consumerDetails.BusinessDetails.BusinessValue, pd.PropertyValue,pd.PropertyType);
                    if(quotes == null)
                    {
                        check = true;
                    }
                }
            }
            return check;
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
                    string quotes = JsonConvert.DeserializeObject<string>(res.data.ToString());
                    return quotes;
                }
                return null;

            }
        }
    }
}
