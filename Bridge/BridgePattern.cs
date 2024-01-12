using System;

// Abstraction interface
interface Abstraction
{
    void Operation();
}

// Implementor interface
interface Implementor
{
    void Operation();
}

// ConcreteImplementor1 class
class ConcreteImplementor1 : Implementor
{
    public void Operation()
    {
        Console.WriteLine("ConcreteImplementor1 operation");
    }
}

// ConcreteImplementor2 class
class ConcreteImplementor2 : Implementor
{
    public void Operation()
    {
        Console.WriteLine("ConcreteImplementor2 operation");
    }
}

// ConcreteAbstraction class
class ConcreteAbstraction : Abstraction
{
    private Implementor imp;

    public ConcreteAbstraction(Implementor imp)
    {
        this.imp = imp;
    }

    public void Operation()
    {
        imp.Operation();
    }
}

// Client code
public class BridgePattern
{
    public static void Main(string[] args)
    {
        Implementor c1 = new ConcreteImplementor1();
        Abstraction abstraction = new ConcreteAbstraction(c1);
        abstraction.Operation();
    }
}
