using ConsumerService.Models;
using ConsumerService.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsumerServiceTests.ServiceTest
{
    [TestFixture]
    class BusinessPropertyServiceTest
    {
        private Mock<IBusinessPropertyService> mock;
        PropertyDetailsModel propertyDetailsModel;
        List<PropertyDetailsModel> pList;

        [SetUp]
        public void SetUp()
        {
            pList = new List<PropertyDetailsModel>() { 

                new PropertyDetailsModel()
                {

                }


             };

            propertyDetailsModel = new PropertyDetailsModel()
            {
                BuildingAge=10,
                BuildingSqft= "2322",
                BuildingStoreys= "10",
                BuildingType= "Industrial",
                BusinessId=0,
                CostoftheAsset= 2000000,
                PropertyType= "Inventory",
                PropertyValue=8,
                SalvageValue= 2500000,
                UseFulLifeOfTheAsset= 30000000


            };
            mock = new Mock<IBusinessPropertyService>();


        }
        [Test]
        public void CreateBusinessProperty_Returns_True()
        {
            mock.Setup(p => p.CreateBusinessProperty(propertyDetailsModel)).Returns(true);
            bool res = mock.Object.CreateBusinessProperty(propertyDetailsModel);
            Assert.AreEqual(true, res);
        }

        [Test]
        public void GetBusinessProperty_Returns_List()
        {
            mock.Setup(p => p.GetBusinessProperty(1)).Returns(pList);
            List<PropertyDetailsModel> PropertyDetailsModelList = mock.Object.GetBusinessProperty(1);
            Assert.AreEqual(pList.Count, PropertyDetailsModelList.Count);
        }
    }
}
