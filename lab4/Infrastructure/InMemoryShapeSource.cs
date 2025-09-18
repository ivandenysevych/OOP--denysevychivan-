using System.Collections.Generic;
using lab4.Domain;

namespace lab4.Infrastructure
{
    // Памʼяттєве джерело: повертає набір фігур для демонстрації
    public class InMemoryShapeSource : IShapeSource
    {
        public IList<IArea> GetShapes()
        {
            return new List<IArea>
            {
                new Circle(3.5),
                new Rectangle(4, 7),
                new Circle(1.2),
                new Rectangle(10, 2.5)
            };
        }
    }
}
