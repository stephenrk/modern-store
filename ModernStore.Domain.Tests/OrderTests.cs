using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Stephen", "Knupfer", "email@email.com", new User("stiff", "stiff"));

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            var mouse = new Product("Mouse", 100, "mouse.jpg", 0);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnInOfStockProductItShouldUpdateQuantityOnHand()
        {
            var mouse = new Product("Mouse", 100, "mouse.jpg", 2);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 0);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderItShouldReturnTotal310()
        {
            var mouse = new Product("Mouse", 300, "mouse.jpg", 2);

            var order = new Order(_customer, 12, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }
    }
}
