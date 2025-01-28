using InDBMemory;
using Microsoft.AspNetCore.Mvc;

[Route("")]
public class TaskController : Controller 
{
    // public ICollection<TaskType> tasks = new List<TaskType>();
    readonly ITaskFileStorage taskFileStorage;

    public TaskController(ITaskFileStorage taskFileStorage)
    {
        this.taskFileStorage = taskFileStorage;
    }

    //Task 1
    [HttpGet("/Task1/Param/2/True")]
    public async Task<IActionResult> Test ()=> Ok("test");

    [HttpPost("Task2")]
    public async Task<IActionResult> Add ([FromBody] TaskType task) 
    {
        // try {
            await taskFileStorage.Add(task);
            return Ok();
        // } catch {
            // return BadRequest();
        // }
    }

    [HttpGet("Task2")]
    public async Task<IActionResult> Get([FromQuery] Guid ID)
    {
        var task = await taskFileStorage.GetTask(ID);
        if(task is null) return NotFound();
        return Ok(task);
    }

    [HttpGet("Task2/1")]
    public async Task<IActionResult> GetTasks() =>
        Ok((await taskFileStorage.GetAllTasks()).ToArray());
}