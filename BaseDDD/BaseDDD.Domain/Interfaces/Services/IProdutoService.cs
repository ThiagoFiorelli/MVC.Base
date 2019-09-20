

using BaseDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BaseDDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
