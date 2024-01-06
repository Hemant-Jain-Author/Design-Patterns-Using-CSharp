class Student {
    String name;
    int id;

    public Student(String name, int id) {
        this.name = name;
        this.id = id;
    }
}

class Model {
    private Student student;

    public Model() {
        this.student = new Student("Harry", 1);
    }

    public void setData(String name, int id) {
        System.out.println("Model: Set data : " + name + " " + id);
        student.name = name;
        student.id = id;
    }

    public Student getData() {
        System.out.println("Model: Get data.");
        return student;
    }
}

class View {
    private Model model;

    public View(Model model) {
        this.model = model;
    }

    public void update() {
        Student student = model.getData();
        System.out.println("View: Student Info, Name: " + student.name + " Id: " + student.id);
    }
}

class Controller {
    private Model model;
    private View view;

    public Controller() {
        this.model = new Model();
        this.view = new View(model);
    }

    public void setData(String name, int id) {
        System.out.println("Controller: Receive data from client.");
        model.setData(name, id);
    }

    public void updateView() {
        System.out.println("Controller: Receive update view from client.");
        view.update();
    }
}

public class MVCPatternStudent {
    public static void main(String[] args) {
        Controller controller = new Controller();
        controller.updateView();

        controller.setData("Jack", 2);
        controller.updateView();
    }
}

/*
Controller: Receive update view from client.
Model: Get data.
View: Student Info, Name: Harry Id: 1
Controller: Receive data from client.
Model: Set data : Jack 2
Controller: Receive update view from client.
Model: Get data.
View: Student Info, Name: Jack Id: 2
*/