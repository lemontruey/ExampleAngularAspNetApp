namespace AngularExampleApp.Core.Models
{
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Bson.Serialization.Attributes;

    public class UserType : BaseEntity
    {
        [BsonElement("allow_edit")]
        public bool IsAllowEditing { get; set; }

        [BsonElement("is_deletable")]
        public bool IsDeletable { get; set; }
    }

    public static class UserTypeExtensions
    {
        public static UserTypeMapping MapToDto(this UserType userType)
        {
            return new UserTypeMapping
            {
                Id = userType.Id,
                Name = userType.Name,
                IsAllowEditing = userType.IsAllowEditing,
                IsDeletable = userType.IsDeletable
            };
        }

        public static UserType MapToEntity(this UserTypeMapping dto)
        {
            return new UserType
            {
                Id = dto.Id,
                Name = dto.Name,
                IsAllowEditing = dto.IsAllowEditing,
                IsDeletable = dto.IsDeletable
            };
        }
    }
}
