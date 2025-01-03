using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Services;
using Moq;

namespace TestApplicationCore.Services.Order
{
    [TestClass]
    public sealed class T02_Order_Add
    {
        [TestMethod]
        public void Add_Article_ReturnOk()
        {
            var mock = new Mock<IOrderRepository>(MockBehavior.Strict);

            var order = new ApplicationCore.Models.Order();
            mock.Setup(x => x.Add(order)).ReturnsAsync(1);

            var service = new OrderService(mock.Object);

            var result = service.Add(order).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
    }
}
