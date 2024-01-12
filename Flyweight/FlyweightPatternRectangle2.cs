using System;
using System.Collections.Generic;

// Shape interface
interface IShape
{
    void Draw(int x1, int y1, int x2, int y2);
}

// Rectangle class implementing Shape with Intrinsic State
class RectangleIntrinsic : IShape
{
    private string color;

    public RectangleIntrinsic(string color)
    {
        this.color = color;
    }

    public void Draw(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Draw rectangle color: {color} topleft: ({x1},{y1}) rightBottom: ({x2},{y2})");
    }
}

// RectangleFactory class for managing Flyweight objects
class RectangleFactory
{
    private readonly Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

    public IShape GetRectangle(string color)
    {
        if (!shapes.ContainsKey(color))
        {
            shapes[color] = new RectangleIntrinsic(color);
        }
        return shapes[color];
    }
}

// Rectangle class without Flyweight
class RectangleWithoutFlyweight
{
    private string color;

    public RectangleWithoutFlyweight(string color)
    {
        this.color = color;
    }

    public void Draw(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Draw rectangle color: {color} topleft: ({x1},{y1}) rightBottom: ({x2},{y2})");
    }
}

// Client code
class FlyweightPatternRectangle2
{
    static void Main(string[] args)
    {
        RectangleFactory factory = new RectangleFactory();
        Random random = new Random();

        long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        for (int i = 0; i < 100; i++)
        {
            IShape rectangle = factory.GetRectangle(random.Next(10).ToString());
            rectangle.Draw(random.Next(100), random.Next(100), random.Next(100), random.Next(100));
        }
        long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        Console.WriteLi
