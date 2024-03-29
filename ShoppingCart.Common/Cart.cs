﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Common
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            // insure that no duplicates are added
            if (Items.Contains(item))
                return;

            Items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        public decimal GetCartTotal()
        {
            decimal total = 0m;

            foreach (CartItem item in Items)
            {
                total += item.GetItemPrice();
            }

            return total;
        }

    }
}
