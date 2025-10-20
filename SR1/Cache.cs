using System;
using System.Collections.Generic;

namespace SR1
{
    // Узагальнений кеш з обмеженнями
    public class Cache<T> where T : class
    {
        private class CacheItem
        {
            public T Value { get; set; }
            public DateTime AddedTime { get; set; }

            public CacheItem(T value)
            {
                Value = value;
                AddedTime = DateTime.Now;
            }
        }

        private List<CacheItem> items = new List<CacheItem>();
        private TimeSpan expirationTime;

        public Cache(TimeSpan expiration)
        {
            expirationTime = expiration;
        }

        // Додавання нового елемента
        public void Add(T item)
        {
            items.Add(new CacheItem(item));
        }

        // Видалення старих елементів
        public void RemoveExpired()
        {
            DateTime now = DateTime.Now;
            items.RemoveAll(i => now - i.AddedTime > expirationTime);
        }

        // Простий алгоритм сортування (Bubble Sort)
        public void Sort(Comparison<T> comparison)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    if (comparison(items[j].Value, items[j + 1].Value) > 0)
                    {
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }

        // Вивід вмісту кешу
        public void Display()
        {
            Console.WriteLine("-- Поточний вміст кешу --");
            foreach (var item in items)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
