using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachine.Controllers;

namespace TrainTicketMachine.Tests.Controllers
{
    [TestClass]
    public class AngularControllerTest
    {
        [TestMethod]
        public void TestIndexHaveCorrectViewTitle()
        {
            // Arrange
            AngularController controller = new AngularController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void TestIndexSetsTitleInViewBag()
        {
            // Arrange
            AngularController controller = new AngularController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Train Station Finder", result.ViewBag.Title);
        }
    }
}