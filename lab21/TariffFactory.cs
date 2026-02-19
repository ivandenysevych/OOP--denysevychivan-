using System;
namespace Lab21 {
    public static class TariffFactory {
        public static ITariffStrategy CreateStrategy(string type) => type.ToLower() switch {
            "prepaid" => new PrepaidTariffStrategy(),
            "contract" => new ContractTariffStrategy(),
            "unlimited" => new UnlimitedTariffStrategy(),
            "family" => new FamilyTariffStrategy(),
            _ => throw new ArgumentException("Невідомий тип тарифу")
        };
    }
}
