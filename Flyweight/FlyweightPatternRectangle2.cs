import java.util.HashMap;
import java.util.Map;
import java.util.Random;

// Shape interface
interface Shape {
    void draw(int x1, int y1, int x2, int y2);
}

// Rectangle class implementing Shape with Intrinsic State
class RectangleIntrinsic implements Shape {
    private String color;

    public RectangleIntrinsic(String color) {
        this.color = color;
    }

    @Override
    public void draw(int x1, int y1, int x2, int y2) {
        System.out.printf("Draw rectangle color: %s topleft: (%s,%s) rightBottom: (%s,%s)%n",
                this.color, x1, y1, x2, y2);
    }
}

// RectangleFactory class for managing Flyweight objects
class RectangleFactory {
    private Map<String, Shape> shapes = new HashMap<>();

    public Shape getRectangle(String color) {
        if (!shapes.containsKey(color)) {
            shapes.put(color, new RectangleIntrinsic(color));
        }
        return shapes.get(color);
    }
}

// Rectangle class without Flyweight
class RectangleWithoutFlyweight {
    private String color;

    public RectangleWithoutFlyweight(String color) {
        this.color = color;
    }

    public void draw(int x1, int y1, int x2, int y2) {
        System.out.printf("Draw rectangle color: %s topleft: (%s,%s) rightBottom: (%s,%s)%n",
                this.color, x1, y1, x2, y2);
    }
}

// Client code
public class FlyweightPatternRectangle2 {
    public static void main(String[] args) {
        RectangleFactory factory = new RectangleFactory();
        Random random = new Random();

        long startTime = System.currentTimeMillis();
        for (int i = 0; i < 100; i++) {
            Shape rectangle = factory.getRectangle(Integer.toString(random.nextInt(10)));
            rectangle.draw(random.nextInt(100), random.nextInt(100), random.nextInt(100), random.nextInt(100));
        }
        long endTime = System.currentTimeMillis();

        System.out.println("Flyweight Time: " + (endTime - startTime) + " ms");

        startTime = System.currentTimeMillis();
        for (int i = 0; i < 10000; i++) {
            RectangleWithoutFlyweight rectangle = new RectangleWithoutFlyweight(Integer.toString(random.nextInt(10)));
            rectangle.draw(random.nextInt(100), random.nextInt(100), random.nextInt(100), random.nextInt(100));
        }
        endTime = System.currentTimeMillis();

        System.out.println("Without Flyweight Time: " + (endTime - startTime) + " ms");
    }
}
