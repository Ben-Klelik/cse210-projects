using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [
            new Square("red", 8.2),
            new Rectangle("green", 10.5, 5),
            new Circle("blue", 10.34)];
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}