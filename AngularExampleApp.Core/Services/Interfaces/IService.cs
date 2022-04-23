namespace AngularExampleApp.Core.Services
{
    using AngularExampleApp.Core.Models.Mappings;

    public interface IService<TDto> where TDto : IBaseMapping
    {
        public List<TDto> List();
        public TDto Add(TDto dto);
        public TDto Edit(TDto dto);
        public void Delete(int id);
    }
}
