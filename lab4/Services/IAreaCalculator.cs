using System.Collections.Generic;
using lab4.Domain;

namespace lab4.Services
{
    // Контракт калькулятора: сума площ, мін/макс, сортування
    public interface IAreaCalculator
    {
        double TotalArea(IEnumerable<IArea> shapes);
        (IArea min, IArea max) MinMax(IEnumerable<IArea> shapes);
        IEnumerable<IArea> SortedByArea(IEnumerable<IArea> shapes);
    }
}
