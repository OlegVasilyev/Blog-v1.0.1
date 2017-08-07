using DataAccessLayerSQL.Context;
using DataAccessLayerSQL.Repositories;
using Entities.Models;
using Moq;
using NUnit.Framework;
using NUnitTestDataAccessLayerSQL.TestData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NUnitTestDataAccessLayerSQL.Repositories
{
    [TestFixture]
    class ArticleRepositoryTest
    {
        [Test, TestCaseSource(typeof(ArticleDataTest), nameof(ArticleDataTest.ArticleData))]
        public void GetAllArticleList(IQueryable<Article> data)
        {                    
            var mockSet = new Mock<DbSet<Article>>();
            mockSet.As<IQueryable<Article>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Article>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Article>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Article>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mock = new Mock<BlogContext>();
            mock.Setup(a => a.Articles).Returns(mockSet.Object);

            var repository = new ArticleRepository(mock.Object);
            var result = repository.GetAll();

            Assert.That(result, Is.TypeOf(typeof(IEnumerable<Article>)));
        }
        [Test]
        public void GetReturnsArticleOnCorrectId()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Article>>();

            mockSet.Setup(a => a.Find(It.IsAny<int>())).Returns(new Article());

            var mock = new Mock<BlogContext>();
            mock.Setup(a => a.Articles).Returns(mockSet.Object);

            //Act
            var repository = new ArticleRepository(mock.Object);
            var result = repository.Get(1);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(Article)));
        }

    }
}
