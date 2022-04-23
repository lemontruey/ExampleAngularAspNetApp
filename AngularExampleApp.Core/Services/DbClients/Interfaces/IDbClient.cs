namespace AngularExampleApp.Core.Services
{
    using MongoDB.Driver;
    public interface IDbClient<T> where T: class
    {
        public IMongoCollection<T> GetCollection();
    }
}
