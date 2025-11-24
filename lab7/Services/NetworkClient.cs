using System;
using System.Net.Http;

namespace lab7.Services
{
    public class NetworkClient
    {
        private int _downloadAttempts = 0;

        // Сценарій: перші 3 спроби кидаємо HttpRequestException, потім успіх
        public string DownloadData(string url)
        {
            _downloadAttempts++;

            Console.WriteLine($"[NetworkClient] Спроба завантаження #{_downloadAttempts} (url = {url})");

            if (_downloadAttempts <= 3)
            {
                // імітація тимчасової мережевої помилки
                throw new HttpRequestException($"Тимчасова помилка доступу до {url}");
            }

            // успішне “завантаження” даних
            return $"[Дані з \"{url}\"]";
        }
    }
}
