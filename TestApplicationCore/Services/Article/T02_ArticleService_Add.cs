using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Moq;

namespace TestApplicationCore.Services.ArticleService
{
    [TestClass]
    public sealed class T02_ArticleService_Add
    {
        [TestMethod]
        public void Add_Article_ReturnOk()
        {
            var mock = new Mock<IArticleRepository>(MockBehavior.Strict);

            var article = new Article();
            mock.Setup(x => x.Add(article)).ReturnsAsync(1);

            var service = new ApplicationCore.Services.ArticleService(mock.Object);

            var result = service.Add(article).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
    }
}
