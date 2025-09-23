using Lab4.Models;
using System;
using System.Collections.Generic;

var shapes = new List<IArea>
{
    new Circle(3.5),
    new Rectangle(4, 7),
    new Circle(1.2),
    new Rectangle(10, 2.5)
};

Console.WriteLine("-- All shapes --");
foreach (var s in shapes)
    Console.WriteLine(s.Describe());

double total = AreaCalculator.TotalArea(shapes);
var min = AreaCalculator.MinArea(shapes);
var max = AreaCalculator.MaxArea(shapes);

Console.WriteLine();
Console.WriteLine($"Total area: {total:0.###}");
Console.WriteLine($"Min area: {min.Describe()}");
Console.WriteLine($"Max area: {max.Describe()}");
