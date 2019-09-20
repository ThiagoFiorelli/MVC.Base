

using BaseDDD.Domain.Entities;
using BaseDDD.Domain.Interfaces;
using BaseDDD.Domain.Interfaces.Repositories;

namespace BaseDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}
