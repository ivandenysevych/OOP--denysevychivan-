using System;

namespace lab5.Models
{
    public class LineItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public LineItem(string name, int quantity, decimal price)
        {
            if (quantity <= 0 || price < 0)
                throw new InvalidItemException($"Невірна кількість або ціна для товару \"{name}\"");

            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public decimal GetTotal() => Quantity * Price;

        public override string ToString() =>
            $"{Name} ×{Quantity} → {GetTotal():0.00} ₴";
    }
}
