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

        public List<User> ListUsers()
        {
            return _users.Find(u => true).ToList();
        }
        
        public User GetUser(int id)
        {
            return _users.Find(u => u.Id == id).FirstOrDefault();
        }

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public User EditUser(User user)
        {
            GetUser(user.Id);
            _users.ReplaceOne(u => u.Id == user.Id, user);
            return user;
        }

        public void DeleteUser(int id)
        {
            _users.DeleteOne(user => user.Id == id);
        }        
    }
}