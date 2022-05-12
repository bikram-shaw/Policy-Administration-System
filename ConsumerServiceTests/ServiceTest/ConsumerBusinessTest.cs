using ConsumerService.Models;
using ConsumerService.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConsumerServiceTests.ServiceTest
{
    [TestFixture]
    class ConsumerBusinessTest
    {
        private Mock<IConsumerBusinessService> mock;
        ConsumerDetailsModel consumerDetailsModel;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IConsumerBusinessService>();
            consumerDetailsModel = new ConsumerDetailsModel()
            {
                Id = 1,
                Name = "Bikram",
                AgentId = 12,
                AgentName = "Sritam",
                Dob = new DateTime(2022 - 05 - 09),
                PanDetails = "ABC009988AVC",
                Phone = "9933759003",
                BusinessDetails = new BusinessDetailsModel()
                {
                    Id = 1,
                    BusinessAge = 1232,
                    BusinessCategory = "ABC",
                    BusinessTurnOver = 2000000,
                    BusinessType = "ABC",
                    BusinessValue = 10,
                    CapitalInvested = 1200000000,
                    TotalEmployee = 120000,
                    PropertyDetails = new List<PropertyDetailsModel>()
                    {
                        new PropertyDetailsModel()
                        {
                            BuildingAge=1,
                            BuildingSqft="2322",
                            BuildingStoreys="10",
                            BuildingType="Industrial",
                            CostoftheAsset=2000000,
                            PropertyType="Inventory",
                            PropertyValue=1,
                            SalvageValue=2500000,
                            UseFulLifeOfTheAsset=30000000,
                            BusinessId=0
                           
                        }
                    }

                }

            };
        }

        [Test]
        public void CreateConsumerService_CreateConsumer_return_True()
        {
            mock.Setup(p => p.CreateConsumer(consumerDetailsModel)).Returns(true);
            bool res = mock.Object.CreateConsumer(consumerDetailsModel);
            Assert.AreEqual(true,res);
        }
        [Test]
        [TestCase(2000000, 1200000000)]
        public void CalculateBusinessValue_return_long(long businessTurnover,long capitalInvsted)
        {
            mock.Setup(p=>p.CalculateBusinessValue(businessTurnover,capitalInvsted)).Returns(10);
         
            Assert.AreEqual(10, mock.Object.CalculateBusinessValue(businessTurnover, capitalInvsted));
        }

        [Test]
        [TestCase(1)]
        public void GetConsumerDetails_Returns_ConsumerDetails(long cId)
        {
            mock.Setup(p => p.GetConsumerDetails(1)).Returns(consumerDetailsModel);
            ConsumerDetailsModel con = mock.Object.GetConsumerDetails(1);
            Assert.AreEqual(consumerDetailsModel, con);
        }




    }
}
