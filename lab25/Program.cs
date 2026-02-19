using System;
using System.Text;
using Lab25.Logging;
using Lab25.Processing;
using Lab25.Notification;

namespace Lab25 {
    class Program {
        static void Main(string[] args) {
            // Налаштовуємо підтримку української мови в консолі
            Console.OutputEncoding = Encoding.UTF8;

            // 1. Ініціалізація логера (Singleton + Factory)
            LoggerManager.Instance.Initialize(new ConsoleLoggerFactory());

            // 2. Створення контексту обробки та видавця (Strategy + Observer)
            var context = new DataContext(new EncryptDataStrategy());
            var publisher = new DataPublisher();
            var observer = new ProcessingLoggerObserver();

            // 3. Підписка спостерігача на подію обробки
            publisher.DataProcessed += observer.OnDataProcessed;

            Console.WriteLine("--- Сценарій 1: Початкова обробка ---");
            string res1 = context.ExecuteProcessing("Текст-1");
            publisher.Publish(res1, context.GetStrategyName());

            Console.WriteLine("\n--- Сценарій 2: Зміна логера на Файловий ---");
            LoggerManager.Instance.Initialize(new FileLoggerFactory());
            string res2 = context.ExecuteProcessing("Текст-2");
            publisher.Publish(res2, context.GetStrategyName());

            Console.WriteLine("\n--- Сценарій 3: Зміна стратегії на Стиснення ---");
            context.SetStrategy(new CompressDataStrategy());
            string res3 = context.ExecuteProcessing("Текст-3");
            publisher.Publish(res3, context.GetStrategyName());
        }
    }
}
