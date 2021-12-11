using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Repositories;

namespace TKMaster.ProjetoAulaAdilson.Core.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        #region Constructor

        public ClienteRepository(MeuContextoBD context) : base(context) { }

        #endregion

        #region Methods

        public async Task<Cliente> NomeExiste(string nomeDoCliente)
        {
            return await DbSet.Where(x => x.Nome.Trim().ToUpper().Equals(nomeDoCliente.Trim().ToUpper())).FirstOrDefaultAsync();
        }

        public async Task<Cliente> DocumentoExiste(string documento)
        {
            return await DbSet.Where(x => x.Documento.Trim().Equals(documento.Trim())).FirstOrDefaultAsync();
        }

        #endregion
    }
}
