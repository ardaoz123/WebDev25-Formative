using System.Text.Json;
using InDBMemory;

public class EFTaskStorage : ITaskStorage
{
    private readonly TaskContext Context;

    public EFTaskStorage(TaskContext context)
    {
        Context = context;
    }

    //why no await?
    public async Task<TaskType> GetTask(Guid taskId) => GetByID(taskId);
    private TaskType GetByID(Guid taskId) => Context.Task.FirstOrDefault(t => t.ID == taskId);
    public async Task<List<TaskType>> GetAllTasks()=> Context.Task.ToList();

    public async Task Add(TaskType task)
    {
        // if(GetTask(task.ID) is null)
        // {
            task.Expiry = task.Expiry.ToUniversalTime();
            Context.Add(task);
            Context.SaveChanges();
        // }
    }


} 