using System;
using System.Collections.Generic;

// Flyweight interface
interface IFlyweight
{
    void Operation(object extrinsicState);
}

// Concrete Flyweight class
class ConcreteFlyweight : IFlyweight
{
    private readonly string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation(object extrinsicState)
    {
        Console.WriteLine($"Flyweight: intrinsicState: {intrinsicState} and extrinsicState: {extrinsicState}");

    }
}

// FlyweightFactory class
class FlyweightFactory
{
    private readonly Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new ConcreteFlyweight(key);
        }
        return flyweights[key];
    }

    public int GetCount()
    {
        return flyweights.Count;
    }
}

// Client code
class FlyweightPattern
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();
        IFlyweight flyweight1 = factory.GetFlyweight("key");
        IFlyweight flyweight2 = factory.GetFlyweight("key");
        flyweight1.Operation("data");
        Console.WriteLine($"{flyweight1} {flyweight2}");
        Console.WriteLine($"Object count: {factory.GetCount()}");
    }
}

/* 
Flyweight: intrinsicState: key and extrinsicState: data
ConcreteFlyweight ConcreteFlyweight
Object count: 1
*/
