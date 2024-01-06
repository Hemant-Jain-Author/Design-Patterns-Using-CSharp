class Animal {
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

    int fly() {
        return 0;
    }
}


class Dodo extends Bird {
    Dodo() {
        super("Dodo");
    }

    void walk() {
        System.out.println("The dodo is extinct and can just walk.");
    }
}

class Eagle extends Bird {
    int flightHeight;

    Eagle() {
        super("Eagle");
    }

    @Override
    int fly() {
        System.out.println("The eagle is soaring through the sky!");
        flightHeight = 1000;
        return flightHeight;
    }
}

class Pigeon extends Bird {
    int flightHeight;

    Pigeon() {
        super("Pigeon");
    }

    @Override
    int fly() {
        System.out.println("The pigeon is fluttering its wings!");
        flightHeight = 100;
        return flightHeight;
    }
}

public class LSP2 {
    static void test(Bird flyingAnimal) {
        int retVal = flyingAnimal.fly();
        if (retVal <= 0) 
            System.out.println("Error: Bird is still at a zero height.");
        else
            System.out.println("Bird is flying at a positive height.");
    }

    public static void main(String[] args) {
        Eagle bird1 = new Eagle();
        test(bird1);

        Pigeon bird2 = new Pigeon();
        test(bird2);

        Dodo bird3 = new Dodo();
        test(bird3);
    }
}

/*
The eagle is soaring through the sky!
Bird is flying at a positive height.
The pigeon is fluttering its wings!
Bird is flying at a positive height.
Error: Bird is still at a zero height.
 */