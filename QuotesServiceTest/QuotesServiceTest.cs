using Moq;
using NUnit.Framework;
using QuotesService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesServiceTest
{
    [TestFixture]
    class QuotesServiceTest
    {
        private Mock<IQuotesService> mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IQuotesService>();

        }

        [Test]
        [TestCase(11,12,"Bikram")]
        public void GetQuotesForPolicy_Returns_String(long businessValue, long propertValue, string propertyType)
        {
            mock.Setup(q => q.GetQuotesForPolicy(businessValue,propertValue,propertyType)).Returns("80000");
            string res = mock.Object.GetQuotesForPolicy(businessValue,propertValue,propertyType);
            Assert.AreEqual("80000", res);
        }

    }
}
