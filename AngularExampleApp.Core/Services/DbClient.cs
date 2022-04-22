namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Configuration;

    public class DbClient : IDbClient
    {
        private readonly UserDbConfiguration userDbConfiguration;
        private readonly IMongoCollection<User> _users;
        public DbClient(IOptions<UserDbConfiguration> options)
        {
            userDbConfiguration = options.Value;

            var client = new MongoClient(userDbConfiguration.ConnectionString);
            var db = client.GetDatabase(userDbConfiguration.UserDatabaseName);

            _users = db.GetCollection<User>(userDbConfiguration.UserCollectionName);
        }

        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}