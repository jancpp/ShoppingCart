using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    public class CartItemTests
    {
        private int _quantity;
        private string _description;
        private decimal _unitPrice;
        private decimal _itemPrice;
        private int _newQuantity;
        private decimal _discount;
        private decimal _largeDiscount;
        private decimal _zero;
        private CartItem _item;

        [SetUp]
        public void Setup()
        {
            _quantity = 10;
            _newQuantity = 7;
            _description = "Test description";
            _unitPrice = 15.00m;
            _itemPrice = 150.00m;
            _discount = 5.00m;
            _largeDiscount = 10000.00m;
            _zero = 0.00m;
            _item = new CartItem(_quantity, _description, _unitPrice);
        }

        [Test]
        public void ItemHasQuantity()
        {
            Assert.That(_item.Quantity, Is.EqualTo(_quantity));
        }

        [Test]
        public void ItemHasDescription()
        {            
            Assert.That(_item.Description, Is.EqualTo("Test description"));
        }

        [Test]
        public void ItemHasUnitPrice()
        {
            Assert.That(_item.UnitPrice, Is.EqualTo(_unitPrice));
        }

        [Test]
        public void ItemPriceIsQuantityTimesUnitPrice()
        {
            Assert.That(_item.GetItemPrice, Is.EqualTo(_itemPrice));
        }

        [Test]
        public void QuantityIsModifiable()
        {
            _item.Quantity = _newQuantity;

            Assert.That(_item.Quantity, Is.EqualTo(_newQuantity));
        }

        [Test]
        public void DiscountCanBeAppliedToItem()
        {
            _item.ApplyDiscount(_discount);

            Assert.That(_item.Discount, Is.EqualTo(_discount));
        }

        [Test]
        public void ItemPriceWithDiscountCannotBeLessThenZero()
        {
            _item.ApplyDiscount(_largeDiscount);
            Assert.That(_item.GetItemPrice(), Is.EqualTo(_zero));
        }
    }
}