using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Services;
using Moq;

namespace TestApplicationCore.Services.Order
{
    [TestClass]
    public sealed class T03_Order_Delete
    {
        [TestMethod]
        public void Delete_Id_ReturnOk()
        {
            var mock = new Mock<IOrderRepository>(MockBehavior.Strict);
            mock.Setup(x => x.Delete(1)).ReturnsAsync(2);
            
            var service = new OrderService(mock.Object);

            var result = service.Delete(1).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result);
        }
    }
}
