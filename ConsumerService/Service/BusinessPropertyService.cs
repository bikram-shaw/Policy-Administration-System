using AutoMapper;
using ConsumerService.Data.Entities;
using ConsumerService.Models;
using ConsumerService.Repository;
using System;
using System.Collections.Generic;

namespace ConsumerService.Service
{
    public class BusinessPropertyService : IBusinessPropertyService
    {
        private readonly IBusinessPropertyRepository businessPropertyRepository;
        private readonly IMapper mapper;

        public BusinessPropertyService(IBusinessPropertyRepository repo,IMapper mapper)
        {
            this.businessPropertyRepository = repo;
            this.mapper = mapper;
        }

        public bool CreateBusinessProperty(PropertyDetailsModel propertyDetailsModel)
        {
            var propertyDetails = new PropertyDetails()
            {
                PropertyType=propertyDetailsModel.PropertyType,
                BuildingSqft=propertyDetailsModel.BuildingSqft,
                BuildingType=propertyDetailsModel.BuildingType,
                BuildingStoreys=propertyDetailsModel.BuildingStoreys,
                BuildingAge=propertyDetailsModel.BuildingAge,
                PropertyValue= CalculateBusinessPropertyValue(propertyDetailsModel.CostoftheAsset, propertyDetailsModel.SalvageValue, propertyDetailsModel.UseFulLifeOfTheAsset),
                CostoftheAsset=propertyDetailsModel.CostoftheAsset,
                UseFulLifeOfTheAsset=propertyDetailsModel.UseFulLifeOfTheAsset,
                SalvageValue=propertyDetailsModel.SalvageValue,
                BusinessId=propertyDetailsModel.BusinessId,
            };

            return businessPropertyRepository.CreateBusinessProperty(propertyDetails);
        }

        public List<PropertyDetailsModel> GetBusinessProperty(long propertyId)
        {
            List<PropertyDetails> PropertyDetails=businessPropertyRepository.GetBusinessProperties(propertyId);
            return mapper.Map<List<PropertyDetailsModel>>(PropertyDetails);
        }

        public bool UpdateBusinessProperty(long propertyId,PropertyDetailsModel propertyDetailsModel)
        {
            PropertyDetails propertyDetails = businessPropertyRepository.GetBusinessProperty(propertyId);
            if(propertyDetails == null)
                return false;
            else
            {
                propertyDetails.PropertyType = propertyDetailsModel.PropertyType;
                propertyDetails.BuildingSqft = propertyDetailsModel.BuildingSqft;
                propertyDetails.BuildingType = propertyDetailsModel.BuildingType;
                propertyDetails.BuildingStoreys = propertyDetailsModel.BuildingStoreys;
                propertyDetails.BuildingAge = propertyDetailsModel.BuildingAge;
                propertyDetails.PropertyValue = propertyDetailsModel.PropertyValue;
                propertyDetails.CostoftheAsset = propertyDetailsModel.CostoftheAsset;
                propertyDetails.UseFulLifeOfTheAsset = propertyDetailsModel.UseFulLifeOfTheAsset;
                propertyDetails.SalvageValue = propertyDetailsModel.SalvageValue;
                
            }
            return businessPropertyRepository.UpdateBusinessProperty(propertyDetails);

        }

        private long CalculateBusinessPropertyValue(long costOfTheAsset, long salvageValue,long useFullLifeOffTheAsset)
        {
            double x_ratio = (costOfTheAsset - salvageValue) / useFullLifeOffTheAsset;

            double Range_min = 0.00;
            double Range_max = 10.00;
            double x_max = (double)(costOfTheAsset / useFullLifeOffTheAsset);

            double x_min = (double)(salvageValue / useFullLifeOffTheAsset);

            double range_diff = (Range_max - Range_min);

            double sat = ((x_ratio - x_min) / (x_max - x_min));

            double propertyvalue = range_diff * sat;
            if (propertyvalue > 10 )
            {
                return 10;
            }
            if (propertyvalue < 10)
            {
                return 5;
            }
            return (long)Math.Abs(Math.Round(propertyvalue));
        }
    }
}
