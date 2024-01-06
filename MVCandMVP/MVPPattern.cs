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

class View {
    public void update(String data) {
        System.out.println("View: Updating the view with data: " + data);
    }
}

class Presenter {
    private Model model;
    private View view;

    public Presenter() {
        this.model = new Model();
        this.view = new View();
    }

    public void setData(String data) {
        System.out.println("Presenter: Receive data from client.");
        model.setData(data);
    }

    public void updateView() {
        System.out.println("Presenter: Receive update view from client.");
        String data = model.getData();
        view.update(data);
    }
}

public class MVPPattern {
    public static void main(String[] args) {
        System.out.println("Client: Pass trigger to Presenter.");
        Presenter presenter = new Presenter();
        presenter.updateView();

        presenter.setData("Hello, Students!");
        presenter.updateView();
    }
}

/*
Client: Pass trigger to Presenter.
Presenter: Receive update view from client.
Model: Get data: Hello, World!
View: Updating the view with data: Hello, World!
Presenter: Receive data from client.
Model: Set data : Hello, Students!
Presenter: Receive update view from client.
Model: Get data: Hello, Students!
View: Updating the view with data: Hello, Students!
*/