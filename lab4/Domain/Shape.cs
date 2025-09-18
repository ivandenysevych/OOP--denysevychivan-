using System;

namespace lab4.Domain
{
    // Абстрактний клас із спільною логікою фігур:
    //  - зберігає назву
    //  - вимагає реалізувати GetArea() у нащадків
    //  - має уніфікований ToString() для виводу площі
    public abstract class Shape : IArea
    {
        public string Name { get; }

        protected Shape(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public abstract double GetArea();

        public override string ToString() => $"{Name}: площа = {GetArea():F2}";
    }
}
