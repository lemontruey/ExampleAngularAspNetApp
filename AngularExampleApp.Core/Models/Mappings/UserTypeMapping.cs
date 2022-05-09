namespace AngularExampleApp.Core.Models.Mappings
{
    public class UserTypeMapping : IBaseMapping
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public bool IsAllowEditing { get; set; }
        public bool IsDeletable { get; set; }
    }
}
