using System;
using Lab25.Logging;
namespace Lab25.Notification {
    // Клас-видавець (Патерн Observer через події)
    public class DataPublisher {
        // Подія, на яку будуть підписуватися спостерігачі
        public event Action<string, string>? DataProcessed;

        // Метод для сповіщення всіх підписаних об'єктів
        public void Publish(string data, string strategy) {
            if (DataProcessed != null) DataProcessed(data, strategy);
        }
    }

    // Конкретний спостерігач, який веде журнал операцій
    public class ProcessingLoggerObserver {
        public void OnDataProcessed(string result, string strategy) {
            // Використання Singleton-менеджера для логування результату
            LoggerManager.Instance.Log("Спостерігач: " + result + " (" + strategy + ")");
        }
    }
}
