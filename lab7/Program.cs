﻿using System;
using System.IO;
using System.Net.Http;
using lab7.Services;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var fileProcessor = new FileProcessor();
            var networkClient = new NetworkClient();

            // Делегат, який вирішує, для яких винятків робити retry
            Func<Exception, bool> shouldRetry = ex =>
                ex is FileNotFoundException ||
                ex is HttpRequestException;

            Console.WriteLine("=== Лабораторна робота №7: IO/Network + Retry ===\n");

            // --------- Сценарій 1: читання файлу з Retry ---------
            Console.WriteLine("== Сценарій: читання файлу з FileProcessor + RetryHelper ==\n");

            try
            {
                string fileResult = RetryHelper.ExecuteWithRetry(
                    operation: () => fileProcessor.ReadFile("data.txt"),
                    retryCount: 3,
                    initialDelay: TimeSpan.FromMilliseconds(500),
                    shouldRetry: shouldRetry
                );

                Console.WriteLine($"\n[Main] Успішне читання файлу: {fileResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Main] Остаточна помилка читання файлу: {ex.GetType().Name} — {ex.Message}");
            }

            Console.WriteLine("\n---------------------------------------------\n");

            // --------- Сценарій 2: мережевий клієнт з Retry ---------
            Console.WriteLine("== Сценарій: мережевий запит з NetworkClient + RetryHelper ==\n");

            try
            {
                string dataResult = RetryHelper.ExecuteWithRetry(
                    operation: () => networkClient.DownloadData("https://example.com/api/data"),
                    retryCount: 4,
                    initialDelay: TimeSpan.FromMilliseconds(500),
                    shouldRetry: shouldRetry
                );

                Console.WriteLine($"\n[Main] Успішне завантаження даних: {dataResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Main] Остаточна помилка завантаження даних: {ex.GetType().Name} — {ex.Message}");
            }

            Console.WriteLine("\n=== Роботу програми завершено. Натисніть будь-яку клавішу... ===");
            Console.ReadKey();
        }
    }
}
