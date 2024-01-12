using System;

// Abstraction interface
interface Shape
{
    void Draw();
}

// Implementor interface
interface Color
{
    string Fill();
}

// Rectangle class
class Rectangle : Shape
{
    private Color imp;

    public Rectangle(Color imp)
    {
        this.imp = imp;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing Rectangle with color {imp.Fill()}");
    }
}

// Circle class
class Circle : Shape
{
    private Color imp;

    public Circle(Color imp)
    {
        this.imp = imp;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing Circle with color {imp.Fill()}");
    }
}

// Red class
class Red : Color
{
    public string Fill()
    {
        return "Red";
    }
}

// Green class
class Green : Color
{
    public string Fill()
    {
        return "Green";
    }
}

// Blue class
class Blue : Color
{
    public string Fill()
    {
        return "Blue";
    }
}

// Client code
public class BridgePatternShape
{
    public static void Main(string[] args)
    {
        Color c1 = new Red();
        Shape abstraction = new Circle(c1);
        abstraction.Draw();

        Color c2 = new Green();
        Shape abstraction2 = new Rectangle(c2);
        abstraction2.Draw();
    }
}
