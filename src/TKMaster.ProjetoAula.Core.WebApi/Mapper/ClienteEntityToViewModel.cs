using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;
using TKMaster.ProjetoAulaAdilson.Core.Utilities;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.DTOs;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.Request.Cliente;

namespace TKMaster.ProjetoAulaAdilson.Core.WebApi.Mapper
{
    public static class ClienteEntityToViewModel
    {
        public static ClienteDTO ToResponse(this Cliente entity)
        {
            return new ClienteDTO()
            {
                Codigo = entity.Codigo,
                Nome = entity.Nome,
                Status = entity.Status,
                Documento = entity.Documento,
                TipoPessoa = entity.TipoPessoa.Trim().ToUpper()
            };
        }

        public static Cliente ToRequest(this RequestAdicionarCliente request)
        {
            return new Cliente()
            {
                Nome = request.Nome,
                Documento = Util.RemoveNaoNumericos(request.Documento),
                TipoPessoa = request.TipoPessoa.Trim().ToUpper()
            };
        }

        public static Cliente ToRequest(this RequestAtualizarCliente request)
        {
            return new Cliente()
            {
                Codigo = request.Codigo,
                Nome = request.Nome,
                Documento = Util.RemoveNaoNumericos(request.Documento),
                TipoPessoa = request.TipoPessoa.Trim().ToUpper()
            };
        }

        public static Cliente ToRequest(this RequestReativarExcluirCliente request)
        {
            return new Cliente()
            {
                Codigo = request.Codigo
            };
        }
    }
}
