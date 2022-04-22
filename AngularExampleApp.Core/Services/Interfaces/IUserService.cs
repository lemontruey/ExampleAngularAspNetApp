namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    public interface IUserService
    {
        public List<User> ListUsers();
        public User GetUser(int id);
        public User AddUser(User user);
        public User EditUser(User user);
        public void DeleteUser(int id);
    }
}
