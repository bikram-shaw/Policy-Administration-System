using AuthService.Models;
using AuthService.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServiceTest
{
    [TestFixture]
    class UserServiceTest
    {
        private Mock<IUserService> mock;
        LoginCredentials loginCred;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IUserService>();
            loginCred = new LoginCredentials("User", "User");
           
        }

        [Test]
        public void AuthenticateUser_Return_UserCred()
        {
            mock.Setup(l => l.AuthenticateUser(loginCred)).Returns(loginCred);
            LoginCredentials user = mock.Object.AuthenticateUser(loginCred);
            Assert.AreEqual(loginCred, user);
        }
    }
}
