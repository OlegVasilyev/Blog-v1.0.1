using BusinessLogicLayer.Service;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using DataAccessLayerInterfaces.Repository;
using Entities.Models;
using Moq;
using NUnit.Framework;
using ValidationLayer.Infrastructure;

namespace UnitTestBusinessLoginLayer.Services
{
    class AnswerServiceTest
    {
        [Test]
        [TestCase(1, 1, null)]
        [TestCase(1, null, "test")]
        [TestCase(null, 1, "test")]
        public void UpdateQuizValidation(int quiention, int votes , string text)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Answers.Update(It.IsAny<Answer>()));

            var _answerService = new AnswerService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _answerService.UpdateAnswer(new AnswerDTO() { QuestionId = quiention, VotesCount = votes, Text = text }));
        }
    }
}
