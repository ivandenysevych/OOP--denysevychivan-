using System;
namespace Lab25.Logging {
    // Інтерфейс логера (визначає загальну дію)
    public interface ILogger { void Log(string message); }

    // Конкретна реалізація для виводу в консоль
    public class ConsoleLogger : ILogger {
        public void Log(string message) { Console.WriteLine("[Консоль] " + message); }
    }

    // Конкретна реалізація для імітації файлового логування
    public class FileLogger : ILogger {
        public void Log(string message) { Console.WriteLine("[Файл] " + message); }
    }

    // Абстрактна фабрика (Патерн Factory Method)
    public abstract class LoggerFactory {
        public abstract ILogger CreateLogger();
    }

    // Реалізація фабрики для консолі
    public class ConsoleLoggerFactory : LoggerFactory {
        public override ILogger CreateLogger() { return new ConsoleLogger(); }
    }

    // Реалізація фабрики для файлів
    public class FileLoggerFactory : LoggerFactory {
        public override ILogger CreateLogger() { return new FileLogger(); }
    }

    // Менеджер логування (Патерн Singleton)
    public class LoggerManager {
        private static LoggerManager? _instance;
        private ILogger? _logger;

        // Приватний конструктор, щоб ніхто не міг створити екземпляр ззовні
        private LoggerManager() { }

        // Глобальна точка доступу до об'єкта
        public static LoggerManager Instance {
            get {
                if (_instance == null) _instance = new LoggerManager();
                return _instance;
            }
        }

        // Метод ініціалізації логера через передану фабрику
        public void Initialize(LoggerFactory factory) { _logger = factory.CreateLogger(); }

        // Метод для логування повідомлень
        public void Log(string message) { if (_logger != null) _logger.Log(message); }
    }
}
