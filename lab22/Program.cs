using System;

namespace Lab22
{
    // ==========================================
    // 1. ПОРУШЕННЯ LSP (Violation)
    // ==========================================
    public class File
    {
        public virtual void Read() => Console.WriteLine("Читання даних з файлу...");
        public virtual void Write(string data) => Console.WriteLine($"Запис даних у файл: {data}");
    }

    public class ReadOnlyFile : File
    {
        public override void Write(string data)
        {
            throw new InvalidOperationException("Помилка: Неможливо записати у файл тільки для читання (LSP Violation)!");
        }
    }

    // ==========================================
    // 2. РІШЕННЯ ЗГІДНО З LSP (Refactored)
    // ==========================================
    
    // Розділяємо інтерфейси
    public interface IReadable { void Read(); }
    public interface IWritable { void Write(string data); }

    // Клас, який вміє тільки читати
    public class SecureReadOnlyFile : IReadable
    {
        public void Read() => Console.WriteLine("Читання з файлу 'Тільки для читання' (LSP OK)");
    }

    // Клас, який вміє і читати, і писати
    public class WritableFile : IReadable, IWritable
    {
        public void Read() => Console.WriteLine("Читання з повноцінного файлу (LSP OK)");
        public void Write(string data) => Console.WriteLine($"Запис у повноцінний файл: {data}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №22 (Варіант 4) ===\n");

            // --- Демонстрація ПОРУШЕННЯ ---
            Console.WriteLine("--- Тест порушення LSP ---");
            File badFile = new ReadOnlyFile(); 
            try {
                // Клієнт очікує, що Write спрацює, бо тип змінної - File
                badFile.Write("Спроба запису"); 
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            // --- Демонстрація ВИПРАВЛЕННЯ ---
            Console.WriteLine("\n--- Тест дотримання LSP ---");
            
            // Тепер ми використовуємо конкретні інтерфейси для конкретних потреб
            IReadable readOnly = new SecureReadOnlyFile();
            readOnly.Read();

            // Створюємо файл, який підтримує обидва інтерфейси
            WritableFile normalFile = new WritableFile();
            normalFile.Read();
            normalFile.Write("Нові дані успішно записані");

            Console.WriteLine("\nПомилка CS1061 виправлена: тепер типи відповідають методам.");
        }
    }
}
