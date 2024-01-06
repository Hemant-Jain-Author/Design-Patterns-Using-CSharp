class Person {
    protected String name;
    protected int age;
    protected String gender;

    public Person(String name, int age, String gender) {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    public String toString() {
        return String.format("Person: %s is a %s and %s years old.", name, gender, age);
    }

    public String getGender() {
        return gender;
    }
}

class Citizen extends Person {
    private int id;

    public Citizen(String name, int age, int id, String gender) {
        super(name, age, gender);
        this.id = id;
    }

    public int getVoterId() {
        return id;
    }

    @Override
    public String toString() {
        return String.format("Citizen: %s is a %s and %s years old with voter id %s.", name, gender, age, id);
    }
}

public class Inheritance {
    public static void main(String[] args) {
        Person p = new Person("John", 32, "Male");
        System.out.println(p);

        Citizen c = new Citizen("Smith", 31, 1234, "Male");
        System.out.println(c);
    }
}
