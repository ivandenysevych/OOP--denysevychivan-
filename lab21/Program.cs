using System;
using Lab21;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Розрахунок мобільного тарифу (Варіант 4) ===");

Console.Write("Введіть тариф (Prepaid, Contract, Unlimited, Family): ");
string type = Console.ReadLine() ?? "Prepaid";

Console.Write("Використані хвилини: ");
int mins = int.TryParse(Console.ReadLine(), out int m) ? m : 0;

Console.Write("Використані ГБ: ");
int gbs = int.TryParse(Console.ReadLine(), out int g) ? g : 0;

try {
    ITariffStrategy strategy = TariffFactory.CreateStrategy(type);
    decimal cost = strategy.CalculateCost(mins, gbs);
    Console.WriteLine($"\nВартість послуг для тарифу {type}: {cost} грн.");
} 
catch (Exception ex) {
    Console.WriteLine($"Помилка: {ex.Message}");
}
