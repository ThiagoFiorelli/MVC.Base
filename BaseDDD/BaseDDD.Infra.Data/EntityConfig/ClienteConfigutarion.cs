

using BaseDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BaseDDD.Infra.Data.EntityConfig
{
    public class ClienteConfigutarion : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfigutarion()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
               .IsRequired()
               .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();
        }
    }
}
