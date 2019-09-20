

using System.Collections.Generic;
using System.Linq;
using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces.Repositories;
using BaseDDD.Domain.Interfaces.Services;

namespace BaseDDD.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscaPorNome(nome);
        }
    }
}
