using System;

// Student class
class Student
{
    private string name;
    private int id;

    public Student(string name, int id)
    {
        this.name = name;
        this.id = id;
    }

    public string GetName()
    {
        return name;
    }

    public int GetId()
    {
        return id;
    }
}

// Model class
class Model
{
    private Student student;

    public Model()
    {
        this.student = new Student("Harry", 1);
    }

    public void SetData(string name, int id)
    {
        Console.WriteLine($"Model: Set data : {name} {id}");
        this.student = new Student(name, id);
    }

    public Student GetData()
    {
        Console.WriteLine("Model: Get data.");
        return student;
    }
}

// View class
class View
{
    public void Update(string name, int id)
    {
        Console.WriteLine($"View: Student Info : {name} {id}");
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

    public void SetData(string name, int id)
    {
        Console.WriteLine("Presenter: Receive data from client.");
        model.SetData(name, id);
    }

    public void UpdateView()
    {
        Console.WriteLine("Presenter: Receive update from client.");
        Student data = model.GetData();
        view.Update(data.GetName(), data.GetId());
    }
}

// Main class (Client code)
class MVPPatternStudent
{
    static void Main(string[] args)
    {
        Presenter presenter = new Presenter();
        presenter.UpdateView();

        presenter.SetData("jack", 2);
        presenter.UpdateView();
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