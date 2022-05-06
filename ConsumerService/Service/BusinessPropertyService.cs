using AutoMapper;
using ConsumerService.Data.Entities;
using ConsumerService.Models;
using ConsumerService.Repository;
using System.Collections.Generic;

namespace ConsumerService.Service
{
    public class BusinessPropertyService : IBusinessPropertyService
    {
        private readonly IBusinessPropertyRepository repo;
        private readonly IMapper mapper;

        public BusinessPropertyService(IBusinessPropertyRepository repo,IMapper mapper)
        {
            this.repo = repo;
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
                PropertyValue=propertyDetailsModel.PropertyValue,
                CostoftheAsset=propertyDetailsModel.CostoftheAsset,
                UseFulLifeOfTheAsset=propertyDetailsModel.UseFulLifeOfTheAsset,
                SalvageValue=propertyDetailsModel.SalvageValue,
                BusinessId=propertyDetailsModel.BusinessId,
            };

            return repo.CreateBusinessProperty(propertyDetails);
        }

        public List<PropertyDetailsModel> GetBusinessProperty(long propertyId)
        {
            List<PropertyDetails> PropertyDetails=repo.GetBusinessProperties(propertyId);
            return mapper.Map<List<PropertyDetailsModel>>(PropertyDetails);
        }

        public bool UpdateBusinessProperty(long propertyId,PropertyDetailsModel propertyDetailsModel)
        {
            PropertyDetails propertyDetails = repo.GetBusinessProperty(propertyId);
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
            return repo.UpdateBusinessProperty(propertyDetails);

            //List<PropertyDetailsModel> propertyDetailsModels = new List<PropertyDetailsModel>();
            //List<PropertyDetails>  propertyDetails= repo.GetBusinessProperty(propertyId);
            //if (propertyDetails == null)
            //    return false;
            //else
            //{
            //    foreach (PropertyDetails property in propertyDetails)
            //    {
            //        propertyDetailsModels.Add(new PropertyDetailsModel()
            //        {
            //            PropertyType = property.PropertyType,
            //            BuildingSqft = property.BuildingSqft,
            //            BuildingType = property.BuildingType,
            //            BuildingStoreys = property.BuildingStoreys,
            //            BuildingAge = property.BuildingAge,
            //            PropertyValue = property.PropertyValue,
            //            CostoftheAsset = property.CostoftheAsset,
            //            UseFulLifeOfTheAsset = property.UseFulLifeOfTheAsset,
            //            SalvageValue = property.SalvageValue,
            //            BusinessId = property.BusinessId,
            //        });
            //    }
            //}
            //return 
        }
    }
}
