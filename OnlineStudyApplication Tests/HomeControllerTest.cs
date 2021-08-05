using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStudyApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStudyApplication_Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnsResult()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void PrivacyLoadPrivacyView()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = (ViewResult)controller.Privacy();

            // Assert
            Assert.AreEqual("Privacy", result.ViewName);

        }

    }
}
