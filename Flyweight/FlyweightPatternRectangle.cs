using System;
using System.Collections.Generic;

// Shape interface
interface IShape
{
    void Draw(int x1, int y1, int x2, int y2);
}

// Rectangle class implementing Shape
class Rectangle : IShape
{
    private string color;

    public Rectangle(string color)
    {
        this.color = color;
    }

    public void Draw(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Draw rectangle color: {color} topleft: ({x1},{y1}) rightBottom: ({x2},{y2})");
    }
}

// RectangleFactory class
class RectangleFactory
{
    private readonly Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

    public IShape GetRectangle(string color)
    {
        if (!shapes.ContainsKey(color))
        {
            shapes[color] = new Rectangle(color);
        }
        return shapes[color];
    }

    public int GetCount()
    {
        return shapes.Count;
    }
}

// Client code
class FlyweightPatternRectangle
{
    static void Main(string[] args)
    {
        RectangleFactory factory = new RectangleFactory();
        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            IShape rectangle = factory.GetRectangle(random.Next(1000).ToString());
            rectangle.Draw(random.Next(100), random.Next(100), random.Next(100), random.Next(100));
        }
        Console.WriteLine(factory.GetCount());
    }
}
