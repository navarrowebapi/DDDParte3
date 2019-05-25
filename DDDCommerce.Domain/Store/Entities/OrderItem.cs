﻿using DDDCommerce.Shared.Entities;

namespace DDDCommerce.Domain.Store.Entities
{
    public class OrderItem : Entity
    {
        //Just for EF
        protected OrderItem()
        {

        }

        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produto fora de estoque");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}