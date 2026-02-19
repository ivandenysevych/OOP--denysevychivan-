namespace Lab21 {
    public class PrepaidTariffStrategy : ITariffStrategy {
        public decimal CalculateCost(int minutes, int gigabytes) => (minutes * 0.5m) + (gigabytes * 10m);
    }

    public class ContractTariffStrategy : ITariffStrategy {
        // Абонплата 100 + дешевші хвилини/ГБ
        public decimal CalculateCost(int minutes, int gigabytes) => 100 + (minutes * 0.2m) + (gigabytes * 5m);
    }

    public class UnlimitedTariffStrategy : ITariffStrategy {
        // Фіксована ціна за все
        public decimal CalculateCost(int minutes, int gigabytes) => 500;
    }

    // Для демонстрації OCP додамо пізніше або відразу
    public class FamilyTariffStrategy : ITariffStrategy {
        public decimal CalculateCost(int minutes, int gigabytes) => (150 + (minutes * 0.1m) + (gigabytes * 3m)) * 0.8m; // Знижка 20%
    }
}
