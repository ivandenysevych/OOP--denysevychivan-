using System;
using System.Threading;

namespace lab7.Services
{
    public static class RetryHelper
    {
        public static T ExecuteWithRetry<T>(
            Func<T> operation,
            int retryCount = 3,
            TimeSpan initialDelay = default,
            Func<Exception, bool> shouldRetry = null)
        {
            if (initialDelay == default)
                initialDelay = TimeSpan.FromSeconds(1);

            int attempt = 0;
            Exception lastException = null;

            while (attempt <= retryCount)
            {
                try
                {
                    attempt++;
                    Console.WriteLine($"[RetryHelper] Спроба #{attempt}...");

                    // виконуємо операцію
                    return operation();
                }
                catch (Exception ex)
                {
                    lastException = ex;

                    bool canRetry =
                        attempt <= retryCount &&
                        (shouldRetry == null || shouldRetry(ex));

                    Console.WriteLine($"[RetryHelper] Помилка на спробі #{attempt}: {ex.GetType().Name} — {ex.Message}");

                    if (!canRetry)
                    {
                        Console.WriteLine("[RetryHelper] Подальші спроби недоцільні. Кидаємо виняток.");
                        throw;
                    }

                    // експоненційна затримка: delay * 2^(attempt-1)
                    var delay = TimeSpan.FromMilliseconds(initialDelay.TotalMilliseconds * Math.Pow(2, attempt - 1));
                    Console.WriteLine($"[RetryHelper] Очікування перед наступною спробою: {delay.TotalMilliseconds} мс");
                    Thread.Sleep(delay);
                }
            }

            // якщо з якоїсь причини не повернули значення — кидаємо останній виняток
            throw lastException ?? new Exception("Unknown error in RetryHelper.");
        }
    }
}
