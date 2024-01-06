import java.util.HashMap;
import java.util.Map;
import java.util.Random;

// Shape interface
interface Shape {
    void draw(int x1, int y1, int x2, int y2);
}

// Rectangle class implementing Shape
class Rectangle implements Shape {
    private String colour;

    public Rectangle(String colour) {
        this.colour = colour;
    }

    @Override
    public void draw(int x1, int y1, int x2, int y2) {
        System.out.printf("Draw rectangle colour: %s topleft: (%s,%s) rightBottom: (%s,%s)%n", 
            this.colour, x1, y1, x2, y2);
    }
}

// RectangleFactory class
class RectangleFactory {
    private Map<String, Shape> shapes = new HashMap<>();

    public Shape getRectangle(String colour) {
        if (!shapes.containsKey(colour)) {
            shapes.put(colour, new Rectangle(colour));
        }
        return shapes.get(colour);
    }

    public int getCount() {
        return shapes.size();
    }
}

// Client code
public class FlyweightPatternRectangle {
    public static void main(String[] args) {
        RectangleFactory factory = new RectangleFactory();
        Random random = new Random();

        for (int i = 0; i < 100; i++) {
            Shape rectangle = factory.getRectangle(Integer.toString(random.nextInt(1000)));
            rectangle.draw(random.nextInt(100), random.nextInt(100), random.nextInt(100), random.nextInt(100));
        }
        System.out.println(factory.getCount());
    }
}
