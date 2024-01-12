using System;
using System.Collections.Generic;

// Model
class Model
{
    private string data;
    private List<Observer> observers;

    public Model()
    {
        this.observers = new List<Observer>();
    }

    public void SetData(string data)
    {
        Console.WriteLine("Model : Set data.");
        this.data = data;
        NotifyObservers();
    }

    public string GetData()
    {
        Console.WriteLine("Model : Get data.");
        return this.data;
    }

    public void AddObserver(Observer observer)
    {
        this.observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        this.observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        Console.WriteLine("Model : Notify observers.");
        foreach (Observer observer in observers)
        {
            observer.Update();
        }
    }
}

// View
class View : Observer
{
    private Controller controller;
    private Model model;

    public View(Model model, Controller controller)
    {
        this.model = model;
        this.controller = controller;
        this.model.AddObserver(this);
    }

    public void Update()
    {
        Console.WriteLine("View : Update.");
        string data = model.GetData();
        Console.WriteLine("Data: " + data);
    }

    public void GetUserInput()
    {
        Console.Write("View : Enter user input: ");
        string userInput = Console.ReadLine();
        controller.HandleUserInput(userInput);
    }
}

// Controller
class Controller
{
    private Model model;
    private View view;

    public Controller(Model m)
    {
        this.model = m;
    }

    public void HandleUserInput(string userInput)
    {
        Console.WriteLine("Controller : Handle user input.");
        model.SetData(userInput);
        // Can inform view about action.
    }

    public void SetView(View v)
    {
        this.view = v;
    }
}

// Observer interface
interface Observer
{
    void Update();
}

// Main class
class MVC
{
    public static void Main(string[] args)
    {
        Model model = new Model();
        Controller controller = new Controller(model);  // The Controller sets itself as the observer in this case
        View view = new View(model, controller);
        controller.SetView(view);
        view.GetUserInput();
    }
}

/*
View : Enter user input: hello, world!
Controller : Handle user input.
Model : Set data.
Model : Notify observers.
View : Update.
Model : Get data.
Data: hello, world!
*/
