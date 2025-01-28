using System.Text.Json;
using InDBMemory;

public class TextFileTaskStorage : ITaskFileStorage
{
    public async Task<TaskType?> GetTask(Guid taskId)
    {
        var path = $"tasks/{taskId}.json";
        if (!File.Exists(path)) return null;
        return JsonSerializer.Deserialize<TaskType>(await File.ReadAllTextAsync(path));
    }
    public async Task Add(TaskType task)
    {
        await File.WriteAllTextAsync($"tasks/{task.ID}.json", JsonSerializer.Serialize(task));
    }

    public async Task<List<TaskType>> GetAllTasks()
    {
        var tasks = new List<TaskType>();
        foreach(var file in Directory.GetFiles("tasks", "*.json"))
        {
            if(File.Exists(file))
            {
                var task = JsonSerializer.Deserialize<TaskType>(await File.ReadAllTextAsync(file));
                if(task is not null)
                {
                    tasks.Add(task);
                }

            }
        }
        return tasks;
    }
    
} 