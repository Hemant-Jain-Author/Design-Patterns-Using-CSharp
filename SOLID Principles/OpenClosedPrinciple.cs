import java.util.ArrayList;
import java.util.List;

abstract class Shape {
    public abstract double area();
}

class Rectangle extends Shape {
    private double height;
    private double width;

    public Rectangle(double h, double w) {
        this.height = h;
        this.width = w;
    }

    @Override
    public double area() {
        return height * width;
    }
}

class Circle extends Shape {
    private double radius;

    public Circle(double r) {
        this.radius = r;
    }

    @Override
    public double area() {
        return Math.PI * radius * radius;
    }
}

public class OpenClosedPrinciple {
    public static double totalArea(List<Shape> shapes) {
        double area = 0;
        for (Shape shape : shapes) {
            area += shape.area();
        }
        return area;
    }

    public static void main(String[] args) {
        Rectangle r = new Rectangle(10, 20);
        Circle c = new Circle(10);

        List<Shape> shapes = new ArrayList<>();
        shapes.add(r);
        shapes.add(c);

        System.out.println(totalArea(shapes));
    }
}
