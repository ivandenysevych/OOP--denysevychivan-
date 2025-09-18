using System;
using System.Collections.Generic;
using System.Linq;
using lab4.Domain;

namespace lab4.Services
{
    // Реалізація калькулятора. Не зберігає стан  працює з переданими наборами фігур.
    public class AreaCalculator : IAreaCalculator
    {
        public double TotalArea(IEnumerable<IArea> shapes)
        {
            if (shapes == null) throw new ArgumentNullException(nameof(shapes));
            return shapes.Sum(s => s.GetArea());
        }

        public (IArea min, IArea max) MinMax(IEnumerable<IArea> shapes)
        {
            if (shapes == null) throw new ArgumentNullException(nameof(shapes));
            var list = shapes.ToList();
            if (list.Count == 0) throw new InvalidOperationException("Набір фігур порожній");

            IArea min = list[0], max = list[0];
            foreach (var s in list)
            {
                if (s.GetArea() < min.GetArea()) min = s;
                if (s.GetArea() > max.GetArea()) max = s;
            }
            return (min, max);
        }

        public IEnumerable<IArea> SortedByArea(IEnumerable<IArea> shapes)
        {
            if (shapes == null) throw new ArgumentNullException(nameof(shapes));
            return shapes.OrderBy(s => s.GetArea()).ToList(); // повертаємо матеріалізований список
        }
    }
}
