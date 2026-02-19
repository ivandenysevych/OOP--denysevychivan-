namespace Lab25.Processing {
    // Інтерфейс стратегії обробки даних (Патерн Strategy)
    public interface IDataProcessorStrategy {
        string Name { get; }
        string Process(string data);
    }

    // Конкретна стратегія: Шифрування
    public class EncryptDataStrategy : IDataProcessorStrategy {
        public string Name { get { return "Шифрування"; } }
        public string Process(string data) { return "Зашифровано(" + data + ")"; }
    }

    // Конкретна стратегія: Стиснення
    public class CompressDataStrategy : IDataProcessorStrategy {
        public string Name { get { return "Стиснення"; } }
        public string Process(string data) { return "Стиснуто(" + data + ")"; }
    }

    // Контекст, який працює з обраною стратегією
    public class DataContext {
        private IDataProcessorStrategy _strategy;

        public DataContext(IDataProcessorStrategy strategy) { _strategy = strategy; }

        // Метод для зміни алгоритму під час виконання
        public void SetStrategy(IDataProcessorStrategy strategy) { _strategy = strategy; }

        public string ExecuteProcessing(string data) { return _strategy.Process(data); }

        public string GetStrategyName() { return _strategy.Name; }
    }
}
