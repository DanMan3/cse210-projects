using System;

class Program
{
    static void Main(string[] args)
    {

        var shapes = new List<Shape>
        {
            new Square("Green", 2.3),
            new Rectangle("Blue", 2.1, 5.2),
            new Circle("Orange", 6.7)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetArea());

        }
    }
}