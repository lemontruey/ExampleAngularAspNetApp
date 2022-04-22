namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<User> _users;
        public DbClient(IOptions<UserDbConfiguration> userDbConfiguration)
        {
            var client = new MongoClient(userDbConfiguration.Value.ConnectionString);
            var db = client.GetDatabase(userDbConfiguration.Value.UserDatabaseName);

            _users = db.GetCollection<User>(userDbConfiguration.Value.UserCollectionName);
        }

        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}