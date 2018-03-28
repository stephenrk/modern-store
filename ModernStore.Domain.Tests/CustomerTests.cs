using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("knupfer", "knupfer");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var name = new Name("", "Knupfer");
            var email = new Email("email@email.com");
            var document = new Document("123456789-10");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var name = new Name("Stephen", "");
            var email = new Email("email@email.com");
            var document = new Document("123456789-10");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var name = new Name("Stephen", "Knupfer");
            var email = new Email("email-invalido");
            var document = new Document("123456789-10");

            var customer = new Customer(name, email, document, user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
