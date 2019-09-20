

namespace BaseDDD.Domain.Entities
{
    public class PedidoItem
    {
        public int ProdutoId { get; set; }
        public virtual Cliente Produto { get; set; }
        public int PedidoId { get; set; }
        public virtual Cliente Pedido { get; set; }
    }
}
