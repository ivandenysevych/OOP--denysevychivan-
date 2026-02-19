using System;
using lab20.Models;
using lab20.Services;
using lab20.Interfaces;

namespace lab20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо сервіси
            IOrderValidator validator = new OrderValidator();
            IOrderRepository repository = new InMemoryOrderRepository();
            IEmailService emailService = new ConsoleEmailService();

            // Створюємо OrderService з DI
            OrderService orderService = new OrderService(validator, repository, emailService);

            // Валідне замовлення
            Order order1 = new Order(1, "Іван", 1500);
            orderService.ProcessOrder(order1);

            Console.WriteLine();

            // Невалідне замовлення
            Order order2 = new Order(2, "Марія", -500);
            orderService.ProcessOrder(order2);

            Console.WriteLine("\n=== Роботу програми завершено ===");
        }
    }
}
