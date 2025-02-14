using System.Text.Json.Serialization;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int? Create(User entity)
        {
            _databaseContext.Set<User>().Add(entity);
            return entity.Id;
        }

        public void Delete(User entity)
        {
            _databaseContext.Set<User>().Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _databaseContext.Set<User>().AsQueryable().ToList();
        }

        public User? GetById(int id)
        {
            return _databaseContext.Set<User>().AsQueryable().Where(e => e.Id == id).FirstOrDefault();
        }

        public bool IsExistingName(string name)
        {
            return _databaseContext.Set<User>().AsQueryable()
                .Where(e => e.Name!.ToLower() == name.ToLower())
                .Select(e => e.Id)
                .Any();
        }

        public void Update(User entity)
        {
            _databaseContext.Update<User>(entity);
        }
    }
}
