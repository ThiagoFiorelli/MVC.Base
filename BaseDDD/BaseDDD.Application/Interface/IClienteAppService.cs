

using BaseDDD.Domain.Entities;
using System.Collections.Generic;

namespace BaseDDD.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
