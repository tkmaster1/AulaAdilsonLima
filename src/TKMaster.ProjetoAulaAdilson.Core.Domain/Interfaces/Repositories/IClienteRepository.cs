using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;

namespace TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente> NomeExiste(string nomeDoCliente);

        Task<Cliente> DocumentoExiste(string documento);
    }
}
