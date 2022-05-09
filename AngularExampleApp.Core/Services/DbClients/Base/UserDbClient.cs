namespace AngularExampleApp.Core.Services
{
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    public abstract class DbClient<T, TOptions> : IDbClient<T>
        where T : class
        where TOptions : BaseConfiguration
    {
        protected IMongoCollection<T> _collection;
        protected TOptions _options;
        protected IMongoDatabase _database;

        public DbClient(IOptions<TOptions> options)
        {
            _options = options.Value;

            try
            {
                var client = new MongoClient(_options.ConnectionString);
                _database = client.GetDatabase(_options.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

        public abstract IMongoCollection<T> GetCollection();
    }
}