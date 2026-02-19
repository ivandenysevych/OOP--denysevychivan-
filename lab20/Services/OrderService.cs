using System;
using lab20.Models;
using lab20.Interfaces;

namespace lab20.Services
{
    public class OrderService
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderRepository _repository;
        private readonly IEmailService _emailService;

        public OrderService(IOrderValidator validator, IOrderRepository repository, IEmailService emailService)
        {
            _validator = validator;
            _repository = repository;
            _emailService = emailService;
        }

        public void ProcessOrder(Order order)
        {
            if (!_validator.IsValid(order))
            {
                Console.WriteLine($"[OrderService] Помилка: Замовлення #{order.Id} невалідне.");
                return;
            }

            _repository.Save(order);
            _emailService.SendOrderConfirmation(order);

            order.Status = OrderStatus.Processed;
            Console.WriteLine($"[OrderService] Статус замовлення #{order.Id} оновлено на {order.Status}.");
        }
    }
}
