class Rectangle {
    private double height;
    private double width;

    public Rectangle(double l, double w) {
        this.height = l;
        this.width = w;
    }

    public void setWidth(double w) {
        this.width = w;
    }

    public void setHeight(double h) {
        this.height = h;
    }

    public double getWidth() {
        return this.width;
    }

    public double getHeight() {
        return this.height;
    }
}

class Square extends Rectangle {
    public Square(double l) {
        super(l, l);
    }

    @Override
    public void setWidth(double w) {
        super.setWidth(w);
        super.setHeight(w);
    }

    @Override
    public void setHeight(double h) {
        super.setWidth(h);
        super.setHeight(h);
    }
}

public class LiskovSubstitutionPrinciple {
    public void testRectangle() {
        Rectangle r = new Rectangle(10, 20);
        r.setHeight(10);
        r.setWidth(20);
        assert 10 * 20 == r.getHeight() * r.getWidth() : "Values are not equal";
    }

    public void testSquare() {
        Square s = new Square(10);
        s.setWidth(20);
        assert 10 * 20 == s.getHeight() * s.getWidth() : "Values are not equal";
    }
}
