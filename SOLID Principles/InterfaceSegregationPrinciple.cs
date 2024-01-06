abstract class Animal {
    String name;

    Animal(String name) {
        this.name = name;
    }

    void eat() {
        System.out.println(name + " is eating.");
    }

    void sleep() {
        System.out.println(name + " is sleeping.");
    }
}

class Bird extends Animal {
    Bird(String name) {
        super(name);
    }

    void makeSound() {
        System.out.println(name + " is making a chirp sound.");
    }
}

interface ICanFly {
    void fly();
}

interface ICanSwim {
    void swim();
}

interface ICanWalk {
    void walk();
}

class Dodo extends Bird implements ICanWalk {
    Dodo(String name) {
        super(name);
    }

    @Override
    public void walk() {
        System.out.println("The dodo is extinct and can just walk.");
    }
}

class Penguin extends Bird implements ICanSwim {
    Penguin(String name) {
        super(name);
    }

    @Override
    public void swim() {
        System.out.println("The penguin is swimming!");
    }
}

class Eagle extends Bird implements ICanFly {
    Eagle(String name) {
        super(name);
    }

    @Override
    public void fly() {
        System.out.println("The eagle is soaring through the sky!");
    }
}

public class InterfaceSegregationPrinciple {
    public static void main(String[] args) {
        Eagle bird1 = new Eagle("Eagle");
        bird1.fly();

        Penguin bird2 = new Penguin("Penguin");
        bird2.swim();

        Dodo bird3 = new Dodo("Dodo");
        bird3.walk();
    }
}

/*
The eagle is soaring through the sky!
The penguin is swimming!
The dodo is extinct and can just walk.
 */
