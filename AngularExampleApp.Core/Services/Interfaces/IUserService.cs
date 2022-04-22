namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    public interface IUserService
    {
        public List<User> ListUsers();
        public User GetUser(int id);
        public void UpdateUser(int id);
        public User CreateUser();
        public void DeleteUser(int id);
    }
}
