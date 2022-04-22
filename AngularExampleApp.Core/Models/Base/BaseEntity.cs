namespace AngularExampleApp.Core.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
