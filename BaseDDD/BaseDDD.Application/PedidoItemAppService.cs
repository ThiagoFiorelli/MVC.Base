

using BaseDDD.Application.Interface;
using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces.Services;

namespace BaseDDD.Application
{
    public class PedidoItemAppService : AppServiceBase<PedidoItem>, IPedidoItemAppService
    {
        private readonly IPedidoItemService _pedidoItemService;

        public PedidoItemAppService(IPedidoItemService pedidoItemService)
            : base(pedidoItemService)
        {
            _pedidoItemService = pedidoItemService;
        }
    }
}
