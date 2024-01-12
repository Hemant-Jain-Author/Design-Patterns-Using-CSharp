using System;

// Model
class Model
{
    private string data;
    private Presenter presenter;

    public void SetData(string data)
    {
        Console.WriteLine("Model: Set data.");
        this.data = data;
        presenter.ModelUpdateEvent();
    }

    public string GetData()
    {
        Console.WriteLine("Model: Get data.");
        return data;
    }

    public void SetPresenter(Presenter presenter)
    {
        this.presenter = presenter;
    }
}

// Presenter
class Presenter
{
    private Model model;
    private View view;

    public Presenter(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void HandleUserInput(string userInput)
    {
        Console.WriteLine("Presenter: Handle user input.");
        model.SetData(userInput);
    }

    public void ModelUpdateEvent()
    {
        Console.WriteLine("Presenter: Model update event.");
        view.Update(model.GetData());
    }
}

// View
class View
{
    private Presenter presenter;

    public void Update(string data)
    {
        Console.WriteLine("View: Update UI.");
        Console.WriteLine("Data: " + data);
    }

    public void SetPresenter(Presenter presenter)
    {
        this.presenter = presenter;
    }

    public void GetUserInput()
    {
        Console.Write("View: Enter user input: ");
        string userInput = "hello, world!";
        Console.WriteLine(userInput);
        //string userInput = Console.ReadLine();
        presenter.HandleUserInput(userInput);
    }
}

// Client code
class MVP
{
    static void Main(string[] args)
    {
        Model model = new Model();
        View view = new View();
        Presenter presenter = new Presenter(model, view);

        model.SetPresenter(presenter);
        view.SetPresenter(presenter);

        view.GetUserInput();
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
