using InDBMemory;

public interface ITaskFileStorage 
{
    Task Add(TaskType task);
    Task<TaskType?> GetTask(Guid taskId);
    Task<List<TaskType>> GetAllTasks();
}