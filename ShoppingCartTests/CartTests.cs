using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShoppingCart.Common;

namespace ShoppingCartTests
{
    [TestFixture]
    class CartTests
    {
        private int _zero;
        private Cart _cart;
        private CartItem _cartItem;
        private CartItem _cartItem2;

        [SetUp]
        public void SetUp()
        {
            _zero = 0;
            _cart = new Cart();
            _cartItem = new CartItem(2, "Test description", 12.00m);
            _cartItem2 = new CartItem(4, "Diffrent description", 5.00m);
        }

        [Test]
        public void CartCanContainZeroItems()
        {
            Assert.That(_cart.Items.Count, Is.EqualTo(_zero));
        }

        [Test]
        public void CartCanAddItem()
        {
            _cart.AddItem(_cartItem);

            Assert.That(_cart.Items, Has.Member(_cartItem));
        }

        [Test]
        public void CartContainsNoDuplicateItems()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem);

            Assert.That(_cart.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void CartCanRemoveItem()
        {
            _cart.AddItem(_cartItem);
            _cart.RemoveItem(_cartItem);

            Assert.That(_cart.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TotalEqualsSumOfItemPrices()
        {
            _cart.AddItem(_cartItem);
            _cart.AddItem(_cartItem2);
            var actualTotal = _cart.GetCartTotal();

            Assert.That(actualTotal, Is.EqualTo(44.00m));

        }
    }
}
