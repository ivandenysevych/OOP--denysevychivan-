using System.Collections.Generic;
using System.Linq;

namespace Lab4.Models;

public static class AreaCalculator
{
    public static double TotalArea(IEnumerable<IArea> shapes) => shapes.Sum(s => s.GetArea());
    public static IArea MinArea(IEnumerable<IArea> shapes) => shapes.MinBy(s => s.GetArea())!;
    public static IArea MaxArea(IEnumerable<IArea> shapes) => shapes.MaxBy(s => s.GetArea())!;
}
