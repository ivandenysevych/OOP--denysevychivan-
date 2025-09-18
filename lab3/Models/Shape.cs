using System;

namespace Lab3.Models
{
    // Абстрактний базовий клас для всіх фігур
    
    public abstract class Shape
    {
        // Назва фігури (доступ лише для нащадків через protected set)
        public string Name { get; protected set; }

        // Конструктор базового класу (встановлює назву фігури)
        protected Shape(string name) => Name = name;

        // Абстрактні методи: обов'язково реалізуються у похідних класах
        public abstract double Area();      // Обчислення площі
        public abstract double Perimeter(); // Обчислення периметра

        // Віртуальний метод: має стандартну реалізацію, але може бути перевизначений
        public virtual string DisplayInfo()
            => $"{Name}: S={Area():0.###}, P={Perimeter():0.###}";

        // ToString викликає DisplayInfo
        public override string ToString() => DisplayInfo();
    }
}
