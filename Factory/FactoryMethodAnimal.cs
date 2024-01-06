import java.util.*;

// Animal interface
interface Animal {
    void voice();
}

// Concrete Animal classes
class Dog implements Animal {
    @Override
    public void voice() {
        System.out.println("Bhow Bhow!!");
    }
}

class Cat implements Animal {
    @Override
    public void voice() {
        System.out.println("Meow Meow!!");
    }
}

// AnimalFactory interface
interface AnimalFactory {
    Animal getAnimal();
}

// Concrete AnimalFactory classes
class CatFactory implements AnimalFactory {
    @Override
    public Animal getAnimal() {
        return new Cat();
    }
}

class DogFactory implements AnimalFactory {
    @Override
    public Animal getAnimal() {
        return new Dog();
    }
}

// Client code
public class FactoryMethodAnimal {
    public static void main(String[] args) {
        AnimalFactory dogFactory = new DogFactory();
        dogFactory.getAnimal().voice();

        AnimalFactory catFactory = new CatFactory();
        catFactory.getAnimal().voice();

        // Future changes to include cow type of objects.
        class Cow implements Animal {
            @Override
            public void voice() {
                System.out.println("Gooaa Gooaa!!");
            }
        }

        class CowFactory implements AnimalFactory {
            @Override
            public Animal getAnimal() {
                return new Cow();
            }
        }

        // Client code for Cow
        AnimalFactory cowFactory = new CowFactory();
        cowFactory.getAnimal().voice();
    }
}
/*
Bhow Bhow!!
Meow Meow!!
Gooaa Gooaa!!
*/
