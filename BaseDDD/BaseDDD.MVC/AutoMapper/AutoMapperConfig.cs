

using AutoMapper;

namespace BaseDDD.MVC.AutoMapper
{
    //Não esta sendo utilizado.
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                cfg.AddProfile<DomainToViewModelMappingProfile>();
            });
            IMapper mapper = configuration.CreateMapper();
        }
    }
}