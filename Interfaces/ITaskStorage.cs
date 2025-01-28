using InDBMemory;

public interface ITaskStorage 
{
    Task Add(TaskType task);
    Task<TaskType?> GetTask(Guid taskId);
    Task<List<TaskType>> GetAllTasks();
}