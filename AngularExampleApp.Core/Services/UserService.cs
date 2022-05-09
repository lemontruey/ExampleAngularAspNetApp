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
        
        public UserService( IDbClient<User> userDbClient,
                            IDbClient<UserType> userTypeDbClient)
        {
            _users      = userDbClient.GetCollection();
            _userTypes  = userTypeDbClient.GetCollection();
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

        public UserMapping Add(UserMapping dto)
        {
            dto.Id = _users.AsQueryable().Max(x => x.Id) + 1;
            _users.InsertOne(dto.MapToEntity());

            return dto;
        }

        public UserMapping Edit(UserMapping dto)
        {
            var user = _users.Find(u => u.Id == dto.Id).FirstOrDefault();
            if (user == null) return null;

            var update = Builders<User>.Update
                            .Set(u => u.Name, dto.Name)
                            .Set(u => u.Login, dto.Login)
                            .Set(u => u.Password, dto.Password)
                            .Set(u => u.LastVisitDate, dto.LastVisitDate)
                            .Set(u => u.UserTypeId, dto.UserTypeId);

            _users.UpdateOne(u => u.Id == dto.Id, update);

            return dto;
        }

        public void Delete(int id)
        {
            _users.DeleteOne(user => user.Id == id);
        }
    }
}