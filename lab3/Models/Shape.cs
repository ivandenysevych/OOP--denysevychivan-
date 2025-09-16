using System;

namespace Lab3.Models
{
    public abstract class Shape
    {
        public string Name { get; protected set; }

        protected Shape(string name) => Name = name;

        public abstract double Area();
        public abstract double Perimeter();

        public override string ToString()
            => $"{Name}: S={Area():0.###}, P={Perimeter():0.###}";
    }
}
