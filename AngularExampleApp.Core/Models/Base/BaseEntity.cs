namespace AngularExampleApp.Core.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    public class BaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId MongoId { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
