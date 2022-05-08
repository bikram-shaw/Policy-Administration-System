﻿using Newtonsoft.Json;
using PolicyService.Data.Entities;
using PolicyService.Models;
using PolicyService.Repository;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PolicyService.Service
{
    public class ConsumerPolicyService : IConsumerPolicyService
    {
        private readonly IConsumerPolicyRepository repository;
        private readonly IHttpClientFactory clientFactory;
        private readonly IPolicyMasterRepository policyMasterRepository;

        public ConsumerPolicyService(IConsumerPolicyRepository repository, IHttpClientFactory clientFactory,IPolicyMasterRepository policyMasterRepository)
        {
            this.repository = repository;
            this.clientFactory = clientFactory;
            this.policyMasterRepository = policyMasterRepository;
        }

        public bool CreateConsumerPolicy(ConsumerPolicyModel consumerPolicyModel)
        {
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
                        BusinessValue = consumerPolicyModel.BusinessValue,
                        ConsumerId = consumerPolicyModel.ConsumerId,
                        ConsumerType = consumerPolicyModel.ConsumerType,
                        PropertyType = consumerPolicyModel.PropertyType,
                        PropertyValue = consumerPolicyModel.PropertyValue,
                        Tenure = consumerPolicyModel.Tenure,
                        Status = "Initiated"
                    };
                    return repository.CreateConsumerPolicy(consumerPolicy);
                }
            }
           return false;
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
                    if(quotes != null)
                    {
                        check = true;
                    }
                }
            }
            return check;
        }

         private ConsumerDetailsModel GetConsumerDetails(long consumerId)
        {
            string BaseUrl = "https://localhost:44391/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
              
                try
                {
                    response = client.GetAsync("api/PensionerDetail/" + consumerId).Result;
                }
                catch (Exception e)
                {
                   

                    response = null;

                }

                if
                    (response != null)
                {
                   

                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    ConsumerDetailsModel consumerDetails = JsonConvert.DeserializeObject<ConsumerDetailsModel>(ObjResponse);
                    return consumerDetails;
                }
                return null;

            }
        }
        private string GetQuotes(long businessValue, long propertyValue,string propertyType)
        {
            string BaseUrl = "https://localhost:44391/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    response = client.GetAsync("api/PensionerDetail/" + businessValue+"/"+ propertyValue+"/"+ propertyType).Result;
                }
                catch (Exception e)
                {


                    response = null;

                }

                if
                    (response != null)
                {


                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    string quotes = JsonConvert.DeserializeObject<string>(ObjResponse);
                    return quotes;
                }
                return null;

            }
        }
    }
}