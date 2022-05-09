namespace AngularExampleApp.Core.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public ObjectId MongoId { get; set; }

        [BsonElement("id")]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
    }
}
