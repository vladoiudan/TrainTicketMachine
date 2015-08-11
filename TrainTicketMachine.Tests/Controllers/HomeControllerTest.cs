using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachine.Controllers;

namespace TrainTicketMachine.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexHaveCorrectViewTitle()
        {
            // Arrange
            HomeController controller = new HomeController();

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
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Train Station Finder", result.ViewBag.Title);
        }
    }
}
