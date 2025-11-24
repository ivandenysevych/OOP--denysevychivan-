using System;
using System.IO;

namespace lab7.Services
{
    public class FileProcessor
    {
        private int _readAttempts = 0;

        // Сценарій: перші 2 спроби кидаємо FileNotFoundException, потім успіх
        public string ReadFile(string path)
        {
            _readAttempts++;

            Console.WriteLine($"[FileProcessor] Спроба читання файлу #{_readAttempts} (path = {path})");

            if (_readAttempts <= 2)
            {
                // імітуємо тимчасову помилку відсутності файлу
                throw new FileNotFoundException($"Файл тимчасово недоступний: {path}");
            }

            // успішне “читання” файлу
            return $"[Вміст файлу \"{path}\"]";
        }
    }
}
