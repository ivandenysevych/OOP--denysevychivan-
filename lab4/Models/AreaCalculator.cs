using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.Models
{
    // Агрегатор/калькулятор: працює з колекцією фігур
    public class AreaCalculator
    {
        public IList<IArea> Shapes { get; }

        public AreaCalculator(IList<IArea> shapes)
        {
            Shapes = shapes ?? throw new ArgumentNullException(nameof(shapes));
        }

        public double TotalArea() => Shapes.Sum(s => s.Area());

        public (IArea min, IArea max) MinMax()
        {
            if (Shapes.Count == 0)
                throw new InvalidOperationException("Shape collection is empty.");

            IArea min = Shapes[0], max = Shapes[0];
            foreach (var s in Shapes)
            {
                if (s.Area() < min.Area()) min = s;
                if (s.Area() > max.Area()) max = s;
            }
            return (min, max);
        }
    }
}
