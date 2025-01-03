using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models;
using Moq;

namespace TestApplicationCore.Services.ArticleService
{
    [TestClass]
    public sealed class T05_ArticleService_GetTotalSalesPerArticle
    {
        [TestMethod]
        public void GetTotalSalesPerArticle_Article_ReturnOk()
        {
            var mock = new Mock<IArticleRepository>(MockBehavior.Strict);

            mock.Setup(x => x.GetTotalSalesPerArticle()).ReturnsAsync(new Dictionary<decimal, Article>
            {
                { 12, new Article { Id = 102 } },
                { 34, new Article { Id = 304 } }
            });

            var service = new ApplicationCore.Services.ArticleService(mock.Object);

            var result = service.GetTotalSalesPerArticle().Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(102, result[12].Id);
            Assert.AreEqual(304, result[34].Id);
        }
    }
}
