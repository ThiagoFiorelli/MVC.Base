using BaseDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BaseDDD.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
