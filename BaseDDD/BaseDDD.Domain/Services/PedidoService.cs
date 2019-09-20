using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces.Repositories;
using BaseDDD.Domain.Interfaces.Services;

namespace BaseDDD.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
            : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
    }
}
