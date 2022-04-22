namespace AngularExampleApp.Models
{
    using AngularExampleApp.Core.Models;
    public class UserMapping : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime LastVisitDate { get; set; }
        public string UserTypeName { get; set; }
    }
}
