using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShoppingCart.Common;
using Moq;

namespace ShoppingCartTests
{
    [TestFixture]
    class CartRepositoryTests
    {
        private MockRepository _mockRepository;
        private Mock<ICartDatabase> _cartDatabase;
        private Cart _cart;
        private CartRepository _cartRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _cartDatabase = _mockRepository.Create<ICartDatabase>();
            _cart = new Cart();
            _cartRepository = new CartRepository(_cartDatabase.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void RepoCanSaveCart()
        {
            _cartDatabase.Setup(c => c.SaveCart(_cart)).Returns(12345);

            var result = _cartRepository.SaveCart(_cart);

            Assert.That(result, Is.EqualTo(12345));
        }

        public void ExceptionsIsSaveCartRturnZero()
        {
            _cartDatabase.Setup(c => c.SaveCart(_cart)).Throws<ApplicationException>();
            var result = _cartRepository.SaveCart(_cart);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
