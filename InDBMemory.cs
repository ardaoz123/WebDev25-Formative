namespace InDBMemory;

public class TaskType
{
    public Guid ID {get; set;}
    public string Name {get; set;}
    public double Price {get; set;}
    public DateOnly Expiry {get; set;}
}

class MyContext {
    public WebApplication App { get;set; }

    public MyContext(WebApplication app) {
        App = app;
    }
}