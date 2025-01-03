using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Services;
using Moq;

namespace TestApplicationCore.Services.Order
{
    [TestClass]
    public sealed class T05_Order_GetAverageArticlePerOrder
    {
        [TestMethod]
        public void GetAverageArticlePerOrder_ReturnOk()
        {
            var mock = new Mock<IOrderRepository>(MockBehavior.Strict);
            mock.Setup(x => x.GetAverageArticlePerOrder()).ReturnsAsync(10);

            var service = new OrderService(mock.Object);

            var result = service.GetAverageArticlePerOrder().Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result);
        }
    }
}
