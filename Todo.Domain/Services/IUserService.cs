using Todo.Domain.Models;

namespace Todo.Domain.Services
{
    public interface IUserService
    {
        public User? GetUser(int id);

        public IEnumerable<User> GetUsers();

        public void Create(string name, string password);

        public void Update(int id, string name);

        public void Delete(int id);
    }
}
