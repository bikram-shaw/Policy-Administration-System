﻿using AutoMapper;
using ConsumerService.Data.Entities;
using ConsumerService.Models;
using ConsumerService.Repository;
using System;

namespace ConsumerService.Service
{
    public class ConsumerBusinessService : IConsumerBusinessService
    {
        private readonly IConsumerBusinessRepository repo;
        private readonly IMapper mapper;

        public ConsumerBusinessService(IConsumerBusinessRepository repo,IMapper mapper)
        {

            this.repo = repo;
            this.mapper = mapper;
        }

        public bool CreateConsumer(ConsumerDetailsModel consumerDetailsModel)
        {
            var consumerDetails = new ConsumerDetails()
            {
                Name = consumerDetailsModel.Name,
                Dob = consumerDetailsModel.Dob,
                PanDetails = consumerDetailsModel.PanDetails,
                Phone = consumerDetailsModel.Phone,
                AgentId = consumerDetailsModel.AgentId,
                AgentName = consumerDetailsModel.AgentName,
                BusinessDetails = new BusinessDetails()
                {
                    BusinessCategory = consumerDetailsModel.BusinessDetails.BusinessCategory,
                    BusinessType = consumerDetailsModel.BusinessDetails.BusinessType,
                    BusinessTurnOver = consumerDetailsModel.BusinessDetails.BusinessTurnOver,
                    CapitalInvested = consumerDetailsModel.BusinessDetails.CapitalInvested,
                    TotalEmployee = consumerDetailsModel.BusinessDetails.TotalEmployee,
                    BusinessValue = CalculateBusinessValue(consumerDetailsModel.BusinessDetails.BusinessTurnOver, consumerDetailsModel.BusinessDetails.CapitalInvested),
                    BusinessAge = consumerDetailsModel.BusinessDetails.BusinessAge
                }
            };
            return repo.CreateConsumer(consumerDetails);
        }

        public ConsumerDetailsModel GetConsumerDetails(long consumerId)
        {
          ConsumerDetails consumerDetails=repo.GetConsumerDetails(consumerId);
          
           return mapper.Map<ConsumerDetailsModel>(consumerDetails);
        }

        public bool UpdateConsumer(long consumerId, ConsumerDetailsModel consumerDetailsModel)
        {
            ConsumerDetails consumerDetails = repo.GetConsumerDetails(consumerId);
            if (consumerDetails == null)
                return false;
            else
            {
                consumerDetails.Name = consumerDetailsModel.Name;
                consumerDetails.Dob = consumerDetailsModel.Dob;
                consumerDetails.PanDetails = consumerDetailsModel.PanDetails;
                consumerDetails.Phone = consumerDetailsModel.Phone;
                consumerDetails.AgentId = consumerDetailsModel.AgentId;
                consumerDetails.AgentName = consumerDetailsModel.AgentName;

               
                consumerDetails.BusinessDetails.BusinessCategory = consumerDetailsModel.BusinessDetails.BusinessCategory;
                consumerDetails.BusinessDetails.BusinessType = consumerDetailsModel.BusinessDetails.BusinessType;
                consumerDetails.BusinessDetails.BusinessTurnOver = consumerDetailsModel.BusinessDetails.BusinessTurnOver;
                consumerDetails.BusinessDetails.CapitalInvested = consumerDetailsModel.BusinessDetails.CapitalInvested;
                consumerDetails.BusinessDetails.TotalEmployee = consumerDetailsModel.BusinessDetails.TotalEmployee;
                consumerDetails.BusinessDetails.BusinessValue = consumerDetailsModel.BusinessDetails.BusinessValue;
                consumerDetails.BusinessDetails.BusinessAge = consumerDetailsModel.BusinessDetails.BusinessAge;
            };
            return repo.UpdateConsumer(consumerDetails);
        }

        private long CalculateBusinessValue(long businessTurnOver,long capitalInvested)
        {
            double x_max =businessTurnOver;
            double x_min =capitalInvested;
            double x_ratio = x_max / x_min;
            double Range_min = 0.00;
            double Range_max = 10.00;
            double range_diff = Range_max - Range_min;
            double sat = ((x_ratio - x_min) / (x_max - x_min));
            double businessvalue = (range_diff * sat);
            return (long)Math.Round(businessvalue);
        }
    }
}
