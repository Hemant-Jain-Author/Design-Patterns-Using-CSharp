using System;

// Model class
class Model
{
    private string data;

    public Model()
    {
        this.data = "Hello, World!";
    }

    public void SetData(string data)
    {
        Console.WriteLine("Model: Set data : " + data);
        this.data = data;
    }

    public string GetData()
    {
        Console.WriteLine("Model: Get data: " + data);
        return data;
    }
}

// View class
class View
{
    private Model model;

    public View(Model model)
    {
        this.model = model;
    }

    // In classic MVC, the view interacts with the model to get data.
    public void Update()
    {
        string data = model.GetData();
        Console.WriteLine("View: Updating the view with data : " + data);
    }
}

// Controller class
class Controller
{
    private Model model;
    private View view;

    public Controller()
    {
        this.model = new Model();
        this.view = new View(model);
    }

    public void SetData(string data)
    {
        Console.WriteLine("Controller: Receive data from client.");
        model.SetData(data);
    }

    public void UpdateView()
    {
        Console.WriteLine("Controller: Receive update view from client.");
        view.Update();
    }
}

// Main class (Client code)
class MVCPattern
{
    static void Main(string[] args)
    {
        Controller controller = new Controller();
        controller.UpdateView();

        controller.SetData("Hello, Students!");
        controller.UpdateView();
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