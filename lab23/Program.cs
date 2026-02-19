using System;

namespace Lab23
{
    // =========================================================
    // 1. ПОРУШЕННЯ ISP ТА DIP (До рефакторингу)
    // =========================================================
    
    // "Товстий" інтерфейс - порушує ISP
    public interface IMultiFunctionDevice {
        void Print();
        void Scan();
        void Fax();
    }

    public class OldSmartMachine : IMultiFunctionDevice {
        // Порушення DIP: клас сам створює свої залежності (new ...)
        public void Print() => Console.WriteLine("Друк документа...");
        public void Scan() => Console.WriteLine("Сканування...");
        public void Fax() => Console.WriteLine("Відправка факсу...");
    }

    // =========================================================
    // 2. РЕФАКТОРИНГ (Дотримання ISP, DIP та DI)
    // =========================================================

    // ISP: Розділяємо інтерфейси на вузькоспеціалізовані
    public interface IPrinter { void Print(); }
    public interface IScanner { void Scan(); }
    public interface IFax    { void Fax(); }

    // DIP: Реалізації тепер незалежні
    public class SimplePrinter : IPrinter {
        public void Print() => Console.WriteLine("[Printer] Друк виконано успішно.");
    }

    public class Photocopier : IPrinter, IScanner {
        public void Print() => Console.WriteLine("[Photocopier] Копія надрукована.");
        public void Scan() => Console.WriteLine("[Photocopier] Документ відскановано.");
    }

    // DI: Головний клас отримує залежності через конструктор
    public class DocumentWorker
    {
        private readonly IPrinter _printer;
        // Ми не додаємо сюди сканер або факс, якщо вони не потрібні 
        // для конкретної операції - це і є суть ISP.

        public DocumentWorker(IPrinter printer)
        {
            _printer = printer; // Впровадження залежності (Constructor Injection)
        }

        public void DoWork() {
            _printer.Print();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №23 (Варіант 4) ===\n");

            // --- Демонстрація DIP/DI ---
            // Ми самі вирішуємо, яку реалізацію "підсунути" воркеру
            IPrinter myHardware = new SimplePrinter();
            DocumentWorker worker = new DocumentWorker(myHardware);
            
            Console.WriteLine("Робота з SimplePrinter:");
            worker.DoWork();

            Console.WriteLine("\nРобота з Photocopier (як принтером):");
            IPrinter photoPrinter = new Photocopier();
            DocumentWorker worker2 = new DocumentWorker(photoPrinter);
            worker2.DoWork();

            Console.WriteLine("\nВисновок: Тепер DocumentWorker не знає про Scan() або Fax(), " +
                              "якщо йому потрібен тільки Print().");
        }
    }
}
