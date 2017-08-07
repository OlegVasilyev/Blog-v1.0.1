using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using EpamBlog.Controllers;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;

namespace NUnitTestEpamBlog.Controllers
{
    [TestFixture]
    public class QuizeControllerTest
    {
        [Test]
        public void IndexGetViewNotNull()
        {
            // Arrange
            var mock = new Mock<IQuizService>();
            mock.Setup(a => a.GetQuizs()).Returns(new List<QuizDTO>());
            QuizeController controller = new QuizeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
