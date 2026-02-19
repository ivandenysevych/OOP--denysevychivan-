using System;
using System.Collections.Generic;

namespace Lab24
{
    //  1. ПАТЕРН STRATEGY
    public interface INumericOperationStrategy {
        string Name { get; }
        double Execute(double value);
    }

    public class SquareOperationStrategy : INumericOperationStrategy {
        public string Name => "Квадрат";
        public double Execute(double value) => value * value;
    }

    public class CubeOperationStrategy : INumericOperationStrategy {
        public string Name => "Куб";
        public double Execute(double value) => value * value * value;
    }

    public class SquareRootOperationStrategy : INumericOperationStrategy {
        public string Name => "Корінь";
        public double Execute(double value) => Math.Sqrt(value);
    }

    public class NumericProcessor {
        private INumericOperationStrategy _strategy;

        public NumericProcessor(INumericOperationStrategy strategy) => _strategy = strategy;

        public void SetStrategy(INumericOperationStrategy strategy) => _strategy = strategy;

        public double Process(double input) => _strategy.Execute(input);

        public string GetCurrentStrategyName() => _strategy.Name;
    }

    // === 2. ПАТЕРН OBSERVER (Subject) ===
    public class ResultPublisher {
        public event Action<double, string>? ResultCalculated;

        public void PublishResult(double result, string operationName) {
            ResultCalculated?.Invoke(result, operationName);
        }
    }

    // 3. СПОСТЕРІГАЧІ (Observers) 
    public class ConsoleLoggerObserver {
        public void OnResultCalculated(double result, string opName) =>
            Console.WriteLine($"[ConsoleLogger] Операція: {opName}, Результат: {result:F2}");
    }

    public class HistoryLoggerObserver {
        public List<string> History { get; } = new List<string>();
        public void OnResultCalculated(double result, string opName) =>
            History.Add($"{DateTime.Now:T}: {opName} = {result:F2}");
    }

    public class ThresholdNotifierObserver {
        private readonly double _threshold;
        public ThresholdNotifierObserver(double threshold) => _threshold = threshold;
        public void OnResultCalculated(double result, string opName) {
            if (result > _threshold)
                Console.WriteLine($"[ALERT] Результат {result:F2} перевищує поріг {_threshold}!");
        }
    }

    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №24: Strategy + Observer ===\n");

            // Налаштування системи
            var publisher = new ResultPublisher();
            var processor = new NumericProcessor(new SquareOperationStrategy());

            // Створення спостерігачів
            var consoleLogger = new ConsoleLoggerObserver();
            var historyLogger = new HistoryLoggerObserver();
            var alertNotifier = new ThresholdNotifierObserver(100.0);

            // Підписка спостерігачів на подію
            publisher.ResultCalculated += consoleLogger.OnResultCalculated;
            publisher.ResultCalculated += historyLogger.OnResultCalculated;
            publisher.ResultCalculated += alertNotifier.OnResultCalculated;

            double[] inputs = { 5, 12, 4 };

            // Виконання операцій з динамічною зміною стратегій
            foreach (var input in inputs) {
                // 1. Обробка
                double result = processor.Process(input);
                
                // 2. Сповіщення спостерігачів
                publisher.PublishResult(result, processor.GetCurrentStrategyName());

                // Динамічно змінюємо стратегію для наступного кроку
                if (input == 5) processor.SetStrategy(new CubeOperationStrategy());
                else if (input == 12) processor.SetStrategy(new SquareRootOperationStrategy());
            }

            Console.WriteLine("\n--- Історія з HistoryLogger ---");
            historyLogger.History.ForEach(Console.WriteLine);
        }
    }
}
