

using BaseDDD.Application.Interface;
using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces.Services;

namespace BaseDDD.Application
{
    public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;

        public PedidoAppService(IPedidoService pedidoService)
            : base(pedidoService)
        {
            _pedidoService = pedidoService;
        }
    }
}
