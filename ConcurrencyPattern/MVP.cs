import java.util.Scanner;

// Model
class Model {
    private String data;
    private Presenter presenter;

    public void setData(String data) {
        System.out.println("Model: Set data.");
        this.data = data;
        presenter.modelUpdateEvent();
    }

    public String getData() {
        System.out.println("Model: Get data.");
        return data;
    }

    public void setPresenter(Presenter presenter) {
        this.presenter = presenter;
    }
}

// Presenter
class Presenter {
    private Model model;
    private View view;

    public Presenter(Model model, View view) {
        this.model = model;
        this.view = view;
    }

    public void handleUserInput(String userInput) {
        System.out.println("Presenter: Handle user input.");
        model.setData(userInput);
    }

    public void modelUpdateEvent() {
        System.out.println("Presenter: Model update event.");
        view.update(model.getData());
    }
}

// View
class View {
    private Presenter presenter;

    public void update(String data) {
        System.out.println("View: Update UI.");
        System.out.println("Data: " + data);
    }

    public void setPresenter(Presenter presenter) {
        this.presenter = presenter;
    }

    public void getUserInput() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("View: Enter user input: ");
        String userInput = "hello, world!";
        System.out.println(userInput);
        //String userInput = scanner.nextLine();
        presenter.handleUserInput(userInput);
    }
}

// Client code
public class MVP {
    public static void main(String[] args) {
        Model model = new Model();
        View view = new View();
        Presenter presenter = new Presenter(model, view);

        model.setPresenter(presenter);
        view.setPresenter(presenter);

        view.getUserInput();
    }
}

/*
View: Enter user input: hello, world!
Presenter: Handle user input.
Model: Set data.
Presenter: Model update event.
Model: Get data.
View: Update UI.
Data: hello, world! 
 */