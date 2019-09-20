

using System.Collections.Generic;
using System.Linq;
using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces;
using BaseDDD.Domain.Interfaces.Repositories;

namespace BaseDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return Db.Produtos.Where(prop => prop.Nome == nome);
        }
    }
}
