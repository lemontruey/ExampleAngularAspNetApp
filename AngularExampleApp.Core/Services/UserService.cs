namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models;
    using AngularExampleApp.Core.Models.Mappings;
    using MongoDB.Driver;
    using System.Linq;

    public class UserService : IService<UserMapping>
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<UserType> _userTypes;
        private readonly IService<UserTypeMapping> _userTypeService;
        public UserService( IDbClient<User> userDbClient,
                            IDbClient<UserType> userTypeDbClient,
                            IService<UserTypeMapping> userTypeService)
        {
            _users = userDbClient.GetCollection();
            _userTypes = userTypeDbClient.GetCollection();
            _userTypeService = userTypeService;
        }

        public List<UserMapping> List()
        {
            return _users.AsQueryable()
                    .Join(
                        _userTypes.AsQueryable(),
                        u => u.UserTypeId,
                        ut => ut.Id,
                        (user, userType) => new { User = user, UserType = userType })
                    .ToList()
                    .Select(x => new UserLookUp { User = x.User, UserType = x.UserType })
                    .Select(x => x.MapToDto())
                    .ToList();
        }

        public UserMapping Add(UserMapping userDto)
        {
            CreateOrEditSubEntities(userDto.UserType);

            var user = GetUserInternal(userDto.Id);
            if (user == null) _users.InsertOne(userDto.MapToEntity());

            return userDto;
        }

        public UserMapping Edit(UserMapping userDto)
        {
            CreateOrEditSubEntities(userDto.UserType);

            var user = GetUserInternal(userDto.Id);
            if (user != null) _users.ReplaceOne(u => u.Id == user.Id, userDto.MapToEntity());

            return userDto;
        }

        public void Delete(int id)
        {
            _users.DeleteOne(user => user.Id == id);
        }
        
        private User GetUserInternal(int id)
        {
            return _users.Find(u => u.Id == id).FirstOrDefault();
        }

        private void CreateOrEditSubEntities(UserTypeMapping dto)
        {
            if (dto == null) return;

            if (dto.Id == 0)
            {
                _userTypeService.Add(dto);
            }
            else
            {
                _userTypeService.Edit(dto);
            }
        }
    }
}