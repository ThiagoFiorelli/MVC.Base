

using System;
using System.Collections.Generic;

namespace BaseDDD.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
