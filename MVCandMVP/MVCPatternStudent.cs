using System;

// Student class
class Student
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Student(string name, int id)
    {
        Name = name;
        Id = id;
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
        student.Name = name;
        student.Id = id;
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
    private Model model;

    public View(Model model)
    {
        this.model = model;
    }

    public void Update()
    {
        Student student = model.GetData();
        Console.WriteLine($"View: Student Info, Name: {student.Name} Id: {student.Id}");
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

    public void SetData(string name, int id)
    {
        Console.WriteLine("Controller: Receive data from client.");
        model.SetData(name, id);
    }

    public void UpdateView()
    {
        Console.WriteLine("Controller: Receive update view from client.");
        view.Update();
    }
}

// Main class (Client code)
class MVCPatternStudent
{
    static void Main(string[] args)
    {
        Controller controller = new Controller();
        controller.UpdateView();

        controller.SetData("Jack", 2);
        controller.UpdateView();
    }
}

/*
Controller: Receive update view from client.
Model: Get data.
View: Student Info, Name: Harry Id: 1
Controller: Receive data from client.
Model: Set data : Jack 2
Controller: Receive update view from client.
Model: Get data.
View: Student Info, Name: Jack Id: 2
*/