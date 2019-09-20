using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces.Repositories;
using BaseDDD.Domain.Interfaces.Services;


namespace BaseDDD.Domain.Services
{
    public class PedidoItemService : ServiceBase<PedidoItem>, IPedidoItemService
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;

        public PedidoItemService(IPedidoItemRepository pedidoItemRepository)
            : base(pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
        }
    }
}
