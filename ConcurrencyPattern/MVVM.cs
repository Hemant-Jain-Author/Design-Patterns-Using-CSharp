import java.util.Scanner;

// Model
class Model {
    private String data;

    public void setData(String data) {
        System.out.println("Model: Set data.");
        this.data = data;
    }

    public String getData() {
        System.out.println("Model: Get data.");
        return data;
    }
}

// ViewModel
class ViewModel {
    private Model model;
    private String data;

    public ViewModel(Model model) {
        this.model = model;
        updateData();
    }

    public void updateModel(String data) {
        System.out.println("ViewModel: Update data.");
        model.setData(data);
        updateData();
    }

    public void updateData() {
        System.out.println("ViewModel: Fetch data.");
        data = model.getData();
    }

    public String getData() {
        return data;
    }
}

// View
class View {
    private ViewModel viewModel;

    public View(ViewModel viewModel) {
        this.viewModel = viewModel;
    }

    public void displayData() {
        System.out.println("Display Data: " + viewModel.getData());
    }

    public void getUserInput() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("View: Enter user input: ");
        /* 
        String userInput = "hello, world!";
        System.out.println(userInput);
        */
        String userInput = scanner.nextLine();
        viewModel.updateModel(userInput);
    }
}

// Client code
public class MVVM {
    public static void main(String[] args) {
        Model model = new Model();
        ViewModel viewModel = new ViewModel(model);
        View view = new View(viewModel);

        // Display initial data
        view.displayData();

        // Get user input and update data
        view.getUserInput();

        // Display updated data
        view.displayData();
    }
}



/*
ViewModel: Fetch data.
Model: Get data.
Display Data: null
View: Enter user input: hello, world!
ViewModel: Update data.
Model: Set data.
ViewModel: Fetch data.
Model: Get data.
Display Data: hello, world!
*/