using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Domain.Services;

namespace Todo.Application.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(
            ITodoListRepository todoListRepository,
            IUserRepository userRepository,
            ITodoTaskRepository repository)
        {
            _todoListRepository = todoListRepository;
            _userRepository = userRepository;
            _repository = repository;
        }

        public void Create(int? ownerId, int? holderId, string description, DateTime dueDate)
        {
            var existingUser = _userRepository.GetById(
                ownerId.GetValueOrDefault());

            if (existingUser is null)
            {
                throw new InvalidProgramException(
                    "User with such name already exists");
            }

            var todoList = _todoListRepository.GetById(
                holderId.GetValueOrDefault());

            if (todoList is null)
            {
                throw new InvalidProgramException(
                    "TodoList with such name already exists");
            }

            _repository.Create(new TodoTask
            {
                Description = description,
                DueDate = dueDate,
                Holder = todoList,
                IsCompleted = false,
                TodoId = holderId
            });
        }

        public void Delete(int id)
        {
            var todoList = _repository.GetById(id);
            if (todoList is null)
            {
                throw new InvalidProgramException(
                    "TodoTask with such id does not exist");
            }

            _repository.Delete(todoList);
        }

        public TodoTask? GetTodoList(int id)
        {
            var todoTask = _repository.GetById(id);
            return todoTask;
        }

        public IEnumerable<TodoTask> GetTodoLists()
        {
            var todoTask = _repository.GetAll();
            return todoTask;
        }

        public void Update(
            int id,
            string description,
            bool isCompleted,
            DateTime dueDate)
        {
            var todoTask = _repository.GetById(id);
            if (todoTask is null)
            {
                throw new InvalidProgramException(
                    "TodoTask with such id does not exist");
            }

            todoTask.Description = description;
            todoTask.IsCompleted = isCompleted;
            todoTask.DueDate = dueDate;

            _repository.Update(todoTask);
        }
    }
}
