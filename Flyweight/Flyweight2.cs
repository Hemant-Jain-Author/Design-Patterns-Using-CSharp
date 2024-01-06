import java.util.HashMap;
import java.util.Map;

// Flyweight interface
interface Flyweight {
    void operation(String extrinsicState);
}

// Concrete Flyweight class
class ConcreteFlyweight implements Flyweight {
    private String intrinsicState;

    public ConcreteFlyweight(String intrinsicState) {
        this.intrinsicState = intrinsicState;
    }

    @Override
    public void operation(String extrinsicState) {
        System.out.println("Operation inside concrete flyweight: " + this);
    }
}

// FlyweightFactory class
class FlyweightFactory {
    private Map<String, Flyweight> flyweights = new HashMap<>();

    public Flyweight getFlyweight(String intrinsicState) {
        if (!flyweights.containsKey(intrinsicState)) {
            flyweights.put(intrinsicState, new ConcreteFlyweight(intrinsicState));
        }
        return flyweights.get(intrinsicState);
    }
}

// ClientClass
class ClientClass {
    public Flyweight flyweight;
    public String extrinsicState;

    public ClientClass(FlyweightFactory factory, String intrinsicState, String extrinsicState) {
        this.flyweight = factory.getFlyweight(intrinsicState);
        this.extrinsicState = extrinsicState;
    }

    public void operation() {
        System.out.println("Operation inside context: " + this);
        flyweight.operation(extrinsicState);
    }
}

// Main class
public class Flyweight2 {
    public static void main(String[] args) {
        FlyweightFactory factory = new FlyweightFactory();
        ClientClass c = new ClientClass(factory, "common", "separate1");
        c.operation();
        ClientClass c2 = new ClientClass(factory, "common", "separate2");
        c2.operation();
    }
}
/*
Operation inside context: ClientClass@8bcc55f
Operation inside concrete flyweight: ConcreteFlyweight@58644d46
Operation inside context: ClientClass@14dad5dc
Operation inside concrete flyweight: ConcreteFlyweight@58644d46

*/

