

using BaseDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BaseDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository: IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(string nome);
    }
}
