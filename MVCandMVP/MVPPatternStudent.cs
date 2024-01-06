class Student {
    private String name;
    private int id;

    public Student(String name, int id) {
        this.name = name;
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public int getId() {
        return id;
    }
}

class Model {
    private Student student;

    public Model() {
        this.student = new Student("Harry", 1);
    }

    public void setData(String name, int id) {
        System.out.println("Model: Set data : " + name + " " + id);
        this.student = new Student(name, id);
    }

    public Student getData() {
        System.out.println("Model: Get data.");
        return student;
    }
}

class View {
    public void update(String name, int id) {
        System.out.println("View: Student Info : " + name + " " + id);
    }
}

class Presenter {
    private Model model;
    private View view;

    public Presenter() {
        this.model = new Model();
        this.view = new View();
    }

    public void setData(String name, int id) {
        System.out.println("Presenter: Receive data from client.");
        model.setData(name, id);
    }

    public void updateView() {
        System.out.println("Presenter: Receive update from client.");
        Student data = model.getData();
        view.update(data.getName(), data.getId());
    }
}

public class MVPPatternStudent {
    public static void main(String[] args) {
        Presenter presenter = new Presenter();
        presenter.updateView();

        presenter.setData("jack", 2);
        presenter.updateView();
    }
}

/*
Presenter: Receive update from client.
Model: Get data.
View: Student Info : Harry 1
Presenter: Receive data from client.
Model: Set data : jack 2
Presenter: Receive update from client.
Model: Get data.
View: Student Info : jack 2
*/