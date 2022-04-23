namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    public class UserDbClient : DbClient<User, UserDbConfiguration>
    {
        public UserDbClient(IOptions<UserDbConfiguration> options) : base(options)
        {
            _options = options.Value;

            _collection = _database.GetCollection<User>(_options.UserCollectionName);
        }

        public override IMongoCollection<User> GetCollection() => _collection;
    }
}