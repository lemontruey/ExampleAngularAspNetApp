namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Driver;
    using System.Linq;

    public class UserTypeService : IService<UserTypeMapping>
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<UserType> _userTypes;
        public UserTypeService( IDbClient<User> userDbClient,
                                IDbClient<UserType> userTypeDbClient)
        {
            _users      = userDbClient.GetCollection();
            _userTypes  = userTypeDbClient.GetCollection();
        }

        List<UserTypeMapping> IService<UserTypeMapping>.List()
        {
            return _userTypes.Find(ut => true).ToEnumerable().Select(ut => ut.MapToDto()).ToList();
        }

        public UserTypeMapping Add(UserTypeMapping dto)
        {
            if (_userTypes.Find(ut => ut.Name == dto.Name).Any())
                throw new Exception("Пользователь с данным именем уже существует");

            dto.Id = _userTypes.AsQueryable().Max(x => x.Id) + 1;
            _userTypes.InsertOne(dto.MapToEntity());

            return dto;
        }

        public UserTypeMapping Edit(UserTypeMapping dto)
        {
            var userType = _userTypes.Find(ut => ut.Id == dto.Id).FirstOrDefault();
            if (userType == null) return null;

            var update = Builders<UserType>.Update
                            .Set(u => u.Name, dto.Name)
                            .Set(u => u.IsAllowEditing, dto.IsAllowEditing)
                            .Set(u => u.IsDeletable, dto.IsDeletable);

            _userTypes.UpdateOne(ut => ut.Id == dto.Id, update);

            return dto;
        }

        public void Delete(int id)
        {
            _users.UpdateMany(user => user.UserTypeId == id,
                              Builders<User>.Update.Set(ut => ut.UserTypeId, 1));

            _userTypes.DeleteOne(usertype => usertype.Id == id);
        }
    }
}