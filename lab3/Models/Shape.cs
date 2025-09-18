using System;

namespace Lab3.Models
{
    /// <summary>
    /// Абстрактний базовий клас. Містить abstract-методи та virtual DisplayInfo().
    /// </summary>
    public abstract class Shape
    {
        public string Name { get; protected set; }

        protected Shape(string name) => Name = name;

        public abstract double Area();
        public abstract double Perimeter();

        public virtual string DisplayInfo()
            => $"{Name}: S={Area():0.###}, P={Perimeter():0.###}";

        public override string ToString() => DisplayInfo();
    }
}
