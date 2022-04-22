namespace AngularExampleApp.Core.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    public class User : BaseEntity
    {
        [BsonElement("login")]
        public string Login { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("last_visit_date")]
        public DateTime LastVisitDate { get; set; }

        [BsonElement("type_id")]
        public int UserType { get; set; }
    }
}
