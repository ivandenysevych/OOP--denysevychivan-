using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5.Models
{
    public class Receipt
    {
        public int Id { get; }
        public DateTime Date { get; }
        public List<LineItem> Items { get; }

        public Receipt(int id)
        {
            Id = id;
            Date = DateTime.Now;
            Items = new List<LineItem>();
        }

        public void AddItem(LineItem item) => Items.Add(item);

        public decimal Subtotal() => Items.Sum(i => i.GetTotal());

        public decimal Vat() => Subtotal() * 0.2m;

        public decimal TotalWithVat() => Subtotal() + Vat();

        public decimal AveragePrice() =>
            Items.Any() ? Items.Average(i => i.Price) : 0;

        public bool HasDiscount() => Subtotal() > 2000;

        public decimal DiscountedTotal()
        {
            var total = TotalWithVat();
            return HasDiscount() ? total * 0.95m : total;
        }

        public override string ToString()
        {
            string items = string.Join("\n", Items.Select(i => i.ToString()));
            return $"--- Receipt #{Id} ---\n{items}\n----------------\n" +
                   $"Subtotal: {Subtotal():0.00} ₴\n" +
                   $"VAT (20%): {Vat():0.00} ₴\n" +
                   $"Total with VAT: {TotalWithVat():0.00} ₴\n" +
                   $"Average price: {AveragePrice():0.00} ₴\n" +
                   $"Discount applied: {(HasDiscount() ? "Yes" : "No")}\n" +
                   $"Final Total: {DiscountedTotal():0.00} ₴";
        }
    }
}
