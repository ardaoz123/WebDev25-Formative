using InDBMemory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<ITaskFileStorage, TextFileTaskStorage>();
var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Urls.Add("http://localhost:5005");

var x = new MyContext(app);

app.Run();
