

using AutoMapper;
using BaseDDD.Domain.Entities;
using BaseDDD.MVC.ViewModels;

namespace BaseDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ReverseMap();
            CreateMap<Produto, ProdutoViewModel>()
                .ReverseMap();
            CreateMap<Pedido, PedidoViewModel>()
                .ReverseMap();
            CreateMap<PedidoItem, PedidoItemViewModel>()
                .ReverseMap();
        }
    }
}