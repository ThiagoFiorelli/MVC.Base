using BaseDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDDD.Infra.Data.EntityConfig
{
    public class PedidoItemConfiguration : EntityTypeConfiguration<PedidoItem>
    {
        public PedidoItemConfiguration()
        {
            HasKey(p => p.PedidoId);
            HasKey(p => p.ProdutoId);
        }
    }
}
