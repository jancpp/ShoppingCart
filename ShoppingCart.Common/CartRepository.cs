using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Common
{
    public class CartRepository
    {
        private ICartDatabase _cartDatabase;

        public CartRepository(ICartDatabase cartDatabase)
        {
            _cartDatabase = cartDatabase;
        }

        public long SaveCart(Cart cart)
        {
            return _cartDatabase.SaveCart(cart);
        }
    }
}
