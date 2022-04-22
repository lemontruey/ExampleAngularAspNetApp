namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;
    public interface IDbClient
    {
        public IMongoCollection<User> GetUsersCollection();
    }
}
