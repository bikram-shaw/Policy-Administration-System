using Moq;
using NUnit.Framework;
using PolicyService.Models;
using PolicyService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyServiceTest
{
    [TestFixture]
    class ConsumerPolicyTest
    {

        private Mock<IConsumerPolicyService> mock;
        PolicyMasterModel policyMasterModel;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IConsumerPolicyService>();
            policyMasterModel = new PolicyMasterModel()
            {
                AssuredSum=1,
                BaseLocation="Chennai",
                BusinessValue=1,
                ConsumerType= "Owner",
                PropertyType= "Building",
                PropertyValue=1,
                Tenure="2 year",
                Type= "Replacement"

            };
        }
        [Test]
        [TestCase("P01")]
        public void GetPolicy_Returns_PolicyMasterModel(string Pid)
        {
            mock.Setup(p => p.GetPolicy(Pid)).Returns(policyMasterModel);
            PolicyMasterModel model = mock.Object.GetPolicy(Pid);
            
            Assert.AreEqual(policyMasterModel, model);
        }
        [Test]
        [TestCase(11,21)]
        public void IssuePolicy_Results_True(long Pid,long Custid)
        {
            mock.Setup(p => p.IssuePolicy(Pid,Custid)).Returns(true);
            bool res = mock.Object.IssuePolicy(Pid,Custid);

            Assert.AreEqual(true, res);
        }

    }
}
