namespace AngularExampleApp.Core.Models.Mappings
{
    public class UserMapping : IBaseMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastVisitDate { get; set; }
        public UserTypeMapping UserType { get; set; }
    }
}
