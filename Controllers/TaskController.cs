using InDBMemory;
using Microsoft.AspNetCore.Mvc;

[Route("")]
public class TaskController : Controller 
{
    readonly ITaskStorage TaskStorage;

    public TaskController(ITaskStorage taskStorage)
    {
        TaskStorage = taskStorage;
    }

    [HttpGet("/Task1/Param/2/True")]
    public async Task<IActionResult> Test ()=> Ok("test");

    [HttpPost("/Task2")]
    public async Task<IActionResult> Add ([FromBody] TaskType task) 
    {
        await TaskStorage.Add(task);
        return Ok();
    }

    [HttpGet("/Task2")]
    public async Task<IActionResult> Get([FromQuery] Guid ID)
    {
        var task = await TaskStorage.GetTask(ID);
        if(task is null) return NotFound();
        return Ok(task);
    }

    [HttpGet("Task2/1")]
    public async Task<IActionResult> GetTasks() =>
        Ok((await TaskStorage.GetAllTasks()).ToArray());
}