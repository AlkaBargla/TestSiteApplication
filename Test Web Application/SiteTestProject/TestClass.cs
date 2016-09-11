using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Site.Controllers;
using System.Web.Mvc;
using Telerik.JustMock;
using Test_Site.Models;


namespace SiteTestProject
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestCreateUserReturnsView()
        {
            HomeController hc = new HomeController();
            ViewResult vr = hc.CreateUser() as ViewResult;
            Assert.That(vr, Is.Not.Null);
        }

        [Test]
        public void TestUserInformationReturnsView()
        {
            HomeController hc = new HomeController();
            User u = new User();
            
            int count = hc.SaveUserInformation(u);
            ViewResult vr = hc.UserInformation(count) as ViewResult;

            Assert.AreEqual(1, count);
            Assert.That(vr, Is.Not.Null);
        }
    }
}
