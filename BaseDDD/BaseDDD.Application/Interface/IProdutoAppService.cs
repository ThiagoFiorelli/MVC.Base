

using BaseDDD.Domain.Entities;
using System.Collections.Generic;

namespace BaseDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
