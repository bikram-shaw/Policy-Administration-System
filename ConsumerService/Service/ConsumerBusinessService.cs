using AutoMapper;
using ConsumerService.Data.Entities;
using ConsumerService.Models;
using ConsumerService.Repository;
using System;
using System.Collections.Generic;

namespace ConsumerService.Service
{
    public class ConsumerBusinessService : IConsumerBusinessService
    {
        private readonly IConsumerBusinessRepository consumerBusinessRepository;
        private readonly IMapper mapper;

        public ConsumerBusinessService(IConsumerBusinessRepository repo,IMapper mapper)
        {

            this.consumerBusinessRepository = repo;
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
            return consumerBusinessRepository.CreateConsumer(consumerDetails);
        }

        public ConsumerDetailsModel GetConsumerDetails(long consumerId)
        {
          ConsumerDetails consumerDetails=consumerBusinessRepository.GetConsumerDetails(consumerId);
            if (consumerDetails == null)
                return null;
            List<PropertyDetailsModel> pDetails = new List<PropertyDetailsModel>();
          foreach(var prop  in consumerDetails.BusinessDetails.Properties)
            {
                pDetails.Add(new PropertyDetailsModel()
                {
                    Id=prop.Id,
                    PropertyType=prop.PropertyType,
                    BuildingSqft=prop.BuildingSqft,
                    BuildingType=prop.BuildingType,
                    BuildingStoreys=prop.BuildingStoreys,
                    BuildingAge=prop.BuildingAge,
                    PropertyValue=prop.PropertyValue,
                    CostoftheAsset=prop.CostoftheAsset,
                    UseFulLifeOfTheAsset=prop.UseFulLifeOfTheAsset,
                    SalvageValue=prop.SalvageValue,


                });
            }
            return new ConsumerDetailsModel() {
                Id=consumerDetails.Id,
                Name = consumerDetails.Name,
                Dob = consumerDetails.Dob,
                PanDetails = consumerDetails.PanDetails,
                Phone = consumerDetails.Phone,
                AgentId = consumerDetails.AgentId,
                AgentName = consumerDetails.AgentName,
                BusinessDetails = new BusinessDetailsModel()
                {
                    Id=consumerDetails.BusinessDetails.Id,
                    BusinessCategory = consumerDetails.BusinessDetails.BusinessCategory,
                    BusinessType = consumerDetails.BusinessDetails.BusinessType,
                    BusinessTurnOver = consumerDetails.BusinessDetails.BusinessTurnOver,
                    CapitalInvested = consumerDetails.BusinessDetails.CapitalInvested,
                    TotalEmployee = consumerDetails.BusinessDetails.TotalEmployee,
                    BusinessValue = consumerDetails.BusinessDetails.BusinessValue,
                    BusinessAge = consumerDetails.BusinessDetails.BusinessAge,
                    PropertyDetails = pDetails
                }
           };
        }

        public bool UpdateConsumer(long consumerId, ConsumerDetailsModel consumerDetailsModel)
        {
            ConsumerDetails consumerDetails = consumerBusinessRepository.GetConsumerDetails(consumerId);
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
            return consumerBusinessRepository.UpdateConsumer(consumerDetails);
        }

        public long CalculateBusinessValue(long businessTurnOver,long capitalInvested)
        {
            double x_max =businessTurnOver;
            double x_min =capitalInvested;
            double x_ratio = x_max / x_min;
            double Range_min = 0.00;
            double Range_max = 10.00;
            double range_diff = Range_max - Range_min;
            double sat = ((x_ratio - x_min) / (x_max - x_min));
            double businessvalue = (range_diff * sat);
            if (businessvalue > 10 )
            {
                return 10;
            }
            return (long)Math.Round(businessvalue);
        }
    }
}
