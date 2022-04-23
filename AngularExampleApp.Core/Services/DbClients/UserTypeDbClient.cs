namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    public class UserTypeDbClient : DbClient<UserType, UserDbConfiguration>
    {
        public UserTypeDbClient(IOptions<UserDbConfiguration> options) : base(options)
        {
            _options = options.Value;

            _collection = _database.GetCollection<UserType>(_options.UserTypeCollectionName);
        }

        public override IMongoCollection<UserType> GetCollection() => _collection;
    }
}