using System;

// Abstract class representing a handler
abstract class Handler
{
    protected Handler successor = null;

    public Handler(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest();
}

// Concrete class representing a handler
class ConcreteHandler1 : Handler
{
    public ConcreteHandler1(Handler successor) : base(successor)
    {
    }

    public override void HandleRequest()
    {
        if (true) // Can handle request.
        {
            Console.WriteLine("Finally handled by ConcreteHandler1");
        }
        else if (successor != null)
        {
            Console.WriteLine("Message passed to next in chain by ConcreteHandler1");
            successor.HandleRequest();
        }
    }
}

// Concrete class representing another handler
class ConcreteHandler2 : Handler
{
    public ConcreteHandler2(Handler successor) : base(successor)
    {
    }

    public override void HandleRequest()
    {
        if (false) // Can't handle request.
        {
            Console.WriteLine("Finally handled by ConcreteHandler2");
        }
        else if (successor != null)
        {
            Console.WriteLine("Message passed to next in chain by ConcreteHandler2");
            successor.HandleRequest();
        }
    }
}

// Client code
public class ChainOfResponsibility
{
    public static void Main(string[] args)
    {
        ConcreteHandler1 ch1 = new ConcreteHandler1(null);
        ConcreteHandler2 ch2 = new ConcreteHandler2(ch1);
        ch2.HandleRequest();
    }
}
