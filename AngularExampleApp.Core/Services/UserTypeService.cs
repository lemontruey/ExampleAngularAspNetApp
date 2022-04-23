namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Driver;
    using System.Linq;

    public class UserTypeService : IService<UserTypeMapping>
    {
        private readonly IMongoCollection<UserType> _userTypes;
        public UserTypeService(IDbClient<User> userDbClient, IDbClient<UserType> userTypeDbClient)
        {
            _userTypes = userTypeDbClient.GetCollection();
        }

        List<UserTypeMapping> IService<UserTypeMapping>.List()
        {
            return _userTypes.Find(x => true).ToEnumerable().Select(x => x.MapToDto()).ToList();
        }

        public UserTypeMapping Add(UserTypeMapping dto)
        {
            var userType = GetUserTypeInternal(dto.Id);

            if (userType == null) _userTypes.InsertOne(dto.MapToEntity());

            return dto;
        }

        public UserTypeMapping Edit(UserTypeMapping dto)
        {
            var userType = dto.MapToEntity();
            if (userType != null) _userTypes.ReplaceOne(x => x.Id == dto.Id, userType);

            return dto;
        }

        public void Delete(int id)
        {
            _userTypes.DeleteOne(user => user.Id == id);
        }

        private UserType GetUserTypeInternal(int id)
        {
            return _userTypes.Find(ut => ut.Id == id).FirstOrDefault();
        }
    }
}