using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Common
{
    public interface ICartDatabase
    {
        long SaveCart(Cart cart);
    }
}
