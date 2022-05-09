namespace AngularExampleApp.Core.Models
{
    using MongoDB.Bson;
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Bson.Serialization.Attributes;

    [Serializable]
    public class User : BaseEntity
    {
        [BsonElement("login")]
        [BsonRepresentation(BsonType.String)]
        public string Login { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonElement("last_visit_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastVisitDate { get; set; }

        [BsonElement("type_id")]
        [BsonRepresentation(BsonType.Int32)]
        public int UserTypeId { get; set; }
    }

    public class UserLookUp
    {
        public User User { get; set; }
        public UserType UserType { get; set; }
    }

    public static class UserExtensions
    {
        public static UserMapping MapToDto(this UserLookUp joinedEntity)
        {
            return new UserMapping
            {
                Id = joinedEntity.User.Id,
                Name = joinedEntity.User.Name,
                Login = joinedEntity.User.Login,
                Password = joinedEntity.User.Password,
                LastVisitDate = joinedEntity.User.LastVisitDate,
                UserTypeId = joinedEntity.UserType.Id,
                UserTypeName = joinedEntity.UserType.Name
            };
        }

        public static User MapToEntity(this UserMapping dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Login = dto.Login,
                Password = dto.Password,
                LastVisitDate = dto.LastVisitDate,
                UserTypeId = dto.UserTypeId
            };
        }
    }
}
