using InDBMemory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskContext>( options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskConnection")));
builder.Services.AddTransient<ITaskStorage, EFTaskStorage>();
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Urls.Add("http://localhost:5005");

var x = new MyContext(app);

app.Run();
