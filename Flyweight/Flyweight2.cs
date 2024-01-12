using System;
using System.Collections.Generic;

// Flyweight interface
interface IFlyweight
{
    void Operation(string extrinsicState);
}

// Concrete Flyweight class
class ConcreteFlyweight : IFlyweight
{
    private readonly string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Flyweight: intrinsicState: {intrinsicState} and extrinsicState: {extrinsicState}");
    }
}

// FlyweightFactory class
class FlyweightFactory
{
    private readonly Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string intrinsicState)
    {
        if (!flyweights.ContainsKey(intrinsicState))
        {
            flyweights[intrinsicState] = new ConcreteFlyweight(intrinsicState);
        }
        return flyweights[intrinsicState];
    }
}

// ClientClass
class ClientClass
{
    public IFlyweight Flyweight { get; }
    public string ExtrinsicState { get; }

    public ClientClass(FlyweightFactory factory, string intrinsicState, string extrinsicState)
    {
        Flyweight = factory.GetFlyweight(intrinsicState);
        ExtrinsicState = extrinsicState;
    }

    public void Operation()
    {
        Console.WriteLine($"Operation inside context: {this}");
        Flyweight.Operation(ExtrinsicState);
    }
}

// Main class
class Flyweight2
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();
        ClientClass c = new ClientClass(factory, "common", "separate1");
        c.Operation();
        ClientClass c2 = new ClientClass(factory, "common", "separate2");
        c2.Operation();
    }
}
/*
Operation inside context: ClientClass
Flyweight: intrinsicState: common and extrinsicState: separate1
Operation inside context: ClientClass
Flyweight: intrinsicState: common and extrinsicState: separate2

*/
