import java.util.HashMap;
import java.util.Map;

// Flyweight interface
interface Flyweight {
    void operation(Object extrinsicState);
}

// Concrete Flyweight class
class ConcreteFlyweight implements Flyweight {
    private String intrinsicState;

    public ConcreteFlyweight(String intrinsicState) {
        this.intrinsicState = intrinsicState;
    }

    @Override
    public void operation(Object extrinsicState) {
        System.out.println("Operation inside concrete flyweight");
    }
}

// FlyweightFactory class
class FlyweightFactory {
    private Map<String, Flyweight> flyweights = new HashMap<>();

    public Flyweight getFlyweight(String key) {
        if (!flyweights.containsKey(key)) {
            flyweights.put(key, new ConcreteFlyweight(key));
        }
        return flyweights.get(key);
    }

    public int getCount() {
        return flyweights.size();
    }
}

// Client code
public class FlyweightPattern {
    public static void main(String[] args) {
        FlyweightFactory factory = new FlyweightFactory();
        Flyweight flyweight1 = factory.getFlyweight("key");
        Flyweight flyweight2 = factory.getFlyweight("key");
        flyweight1.operation(null);
        System.out.println(flyweight1 + " " + flyweight2);
        System.out.println("Object count: " + factory.getCount());
    }
}

/* 
Operation inside concrete flyweight
ConcreteFlyweight@73d16e93 ConcreteFlyweight@73d16e93
Object count: 1
*/