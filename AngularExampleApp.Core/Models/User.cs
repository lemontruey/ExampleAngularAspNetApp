namespace AngularExampleApp.Core.Models
{
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Linq.Expressions;

    [Serializable]
    public class User : BaseEntity
    {
        [BsonElement("login")]
        public string Login { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("last_visit_date")]
        public DateTime LastVisitDate { get; set; }

        [BsonElement("type_id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
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
                UserType = new UserTypeMapping()
                {
                    Id = joinedEntity.UserType.Id,
                    Name = joinedEntity.UserType.Name,
                    IsAllowEditing = joinedEntity.UserType.IsAllowEditing
                }
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
                UserTypeId = dto.UserType?.Id ?? 0
            };
        }
    }
}
