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
        Console.WriteLine($"Model: Set data : {data}");
        this.data = data;
    }

    public string GetData()
    {
        Console.WriteLine($"Model: Get data: {data}");
        return data;
    }
}

// View class
class View
{
    public void Update(string data)
    {
        Console.WriteLine($"View: Updating the view with data: {data}");
    }
}

// Presenter class
class Presenter
{
    private Model model;
    private View view;

    public Presenter()
    {
        this.model = new Model();
        this.view = new View();
    }

    public void SetData(string data)
    {
        Console.WriteLine("Presenter: Receive data from client.");
        model.SetData(data);
    }

    public void UpdateView()
    {
        Console.WriteLine("Presenter: Receive update view from client.");
        string data = model.GetData();
        view.Update(data);
    }
}

// Main class (Client code)
class MVPPattern
{
    static void Main(string[] args)
    {
        Console.WriteLine("Client: Pass trigger to Presenter.");
        Presenter presenter = new Presenter();
        presenter.UpdateView();

        presenter.SetData("Hello, Students!");
        presenter.UpdateView();
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