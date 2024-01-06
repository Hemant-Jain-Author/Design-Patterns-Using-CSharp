// DRY - Don't repeat yourself.
// Expect changes - Software always changes.
// SOLID principles

// Class should have only one reason to change.

// CRUD operations - Create Read Update Delete

class Student {
    private String name;

    public Student(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}

class BTechStudent extends Student {
    public BTechStudent(String name) {
        super(name);
    }
}

class MTechStudent extends Student {
    public MTechStudent(String name) {
        super(name);
    }
}

class CoursesManager {
    public void registerStudents(Student student, String course) {
        System.out.println("Register student to course.");
        // Implement registration logic
    }

    public void getPayment(Student student, String course, IPayment payment) {
        payment.makePayment();
        System.out.println("Payment received.");
    }
}

interface IPayment {
    void makePayment();
}

class CashPayment implements IPayment {
    @Override
    public void makePayment() {
        System.out.println("Make cash payment.");
    }

    public void countCash() {
        System.out.println("Counting cash.");
    }
}

class CardPayment implements IPayment {
    @Override
    public void makePayment() {
        System.out.println("Make card payment.");
    }
}

class NetBankingPayment implements IPayment {
    @Override
    public void makePayment() {
        System.out.println("Make net-banking payment.");
    }
}
