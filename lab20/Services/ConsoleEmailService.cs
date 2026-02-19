using System;
using lab20.Models;
using lab20.Interfaces;

namespace lab20.Services
{
    public class ConsoleEmailService : IEmailService
    {
        public void SendOrderConfirmation(Order order)
        {
            Console.WriteLine($"[EmailService] Відправлено підтвердження для замовлення #{order.Id} ({order.CustomerName}).");
        }
    }
}
