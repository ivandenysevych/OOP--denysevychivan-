using System;

namespace Lab4.Models
{
    // Абстрактний базовий клас: спільна логіка для всіх фігур
    public abstract class Shape : IArea
    {
        public string Name { get; protected set; }

        protected Shape(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name must be non-empty.", nameof(name));
            Name = name;
        }

        public abstract double Area();

        public virtual string DisplayInfo() => $"{Name}: S={Area():0.###}";

        public override string ToString() => DisplayInfo();
    }
}
