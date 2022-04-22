namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;

    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IDbClient dbClient)
        {
            _users = dbClient.GetUsersCollection();
        }
        public List<User> ListUsers() => _users.Find(x => true).ToList();
        
        public User GetUser(int id) => _users.Find(x => x.Id == id).FirstOrDefault();

        public User CreateUser()
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}