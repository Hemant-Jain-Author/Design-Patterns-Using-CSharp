// Model class
class Model {
    private String data;

    public Model() {
        this.data = "Hello, World!";
    }

    public void setData(String data) {
        System.out.println("Model: Set data : " + data);
        this.data = data;
    }

    public String getData() {
        System.out.println("Model: Get data: " + data);
        return data;
    }
}

// View class
class View {
    private Model model;

    public View(Model model) {
        this.model = model;
    }

    // In classic MVC, the view interacts with the model to get data.
    public void update() {
        String data = model.getData();
        System.out.println("View: Updating the view with data : " + data);
    }
}

// Controller class
class Controller {
    private Model model;
    private View view;

    public Controller() {
        this.model = new Model();
        this.view = new View(model);
    }

    public void setData(String data) {
        System.out.println("Controller: Receive data from client.");
        model.setData(data);
    }

    public void updateView() {
        System.out.println("Controller: Receive update view from client.");
        view.update();
    }
}

// Main class (Client code)
public class MVCPattern {
    public static void main(String[] args) {
        Controller controller = new Controller();
        controller.updateView();

        controller.setData("Hello, Students!");
        controller.updateView();
    }
}

/*
Controller: Receive update view from client.
Model: Get data: Hello, World!
View: Updating the view with data : Hello, World!
Controller: Receive data from client.
Model: Set data : Hello, Students!
Controller: Receive update view from client.
Model: Get data: Hello, Students!
View: Updating the view with data : Hello, Students!
*/