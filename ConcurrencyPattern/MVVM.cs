using System;

// Model
class Model
{
    private string data;

    public void SetData(string data)
    {
        Console.WriteLine("Model: Set data.");
        this.data = data;
    }

    public string GetData()
    {
        Console.WriteLine("Model: Get data.");
        return data;
    }
}

// ViewModel
class ViewModel
{
    private Model model;
    private string data;

    public ViewModel(Model model)
    {
        this.model = model;
        UpdateData();
    }

    public void UpdateModel(string data)
    {
        Console.WriteLine("ViewModel: Update data.");
        model.SetData(data);
        UpdateData();
    }

    public void UpdateData()
    {
        Console.WriteLine("ViewModel: Fetch data.");
        data = model.GetData();
    }

    public string GetData()
    {
        return data;
    }
}

// View
class View
{
    private ViewModel viewModel;

    public View(ViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public void DisplayData()
    {
        Console.WriteLine("Display Data: " + viewModel.GetData());
    }

    public void GetUserInput()
    {
        Console.Write("View: Enter user input: ");
        string userInput = "hello, world!";
        Console.WriteLine(userInput);
        //string userInput = Console.ReadLine();
        viewModel.UpdateModel(userInput);
    }
}

// Client code
class MVVM
{
    static void Main(string[] args)
    {
        Model model = new Model();
        ViewModel viewModel = new ViewModel(model);
        View view = new View(viewModel);

        // Display initial data
        view.DisplayData();

        // Get user input and update data
        view.GetUserInput();

        // Display updated data
        view.DisplayData();
    }
}

/*
ViewModel: Fetch data.
Model: Get data.
Display Data: 
View: Enter user input: hello, world!
ViewModel: Update data.
Model: Set data.
ViewModel: Fetch data.
Model: Get data.
Display Data: hello, world!
*/
