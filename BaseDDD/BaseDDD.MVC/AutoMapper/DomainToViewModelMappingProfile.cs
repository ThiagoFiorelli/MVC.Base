

using AutoMapper;
using BaseDDD.Domain.Entities;
using BaseDDD.MVC.ViewModels;

namespace BaseDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                .ReverseMap();
            CreateMap<ProdutoViewModel, Produto>()
                .ReverseMap();
            CreateMap<PedidoViewModel, Pedido>()
                .ReverseMap();
            CreateMap<PedidoItemViewModel, PedidoItem>()
                .ReverseMap();
        }
    }
}