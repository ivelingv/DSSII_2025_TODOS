using Todo.Domain.Models;

namespace Todo.Domain.Services
{
    public interface ITodoTaskService
    {
        void Create(int? ownerId, int? holderId, string description, DateTime dueDate);
        void Delete(int id);
        TodoTask? GetTodoList(int id);
        IEnumerable<TodoTask> GetTodoLists();
        void Update(int id, string description, bool isCompleted, DateTime dueDate);
    }
}