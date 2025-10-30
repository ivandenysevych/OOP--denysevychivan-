using System;

namespace lab6.Models
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Category { get; }

        public Product(string name, decimal price, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.", nameof(category));

            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString() => $"{Name} ({Category}) — {Price:0.00} ₴";
    }
}
