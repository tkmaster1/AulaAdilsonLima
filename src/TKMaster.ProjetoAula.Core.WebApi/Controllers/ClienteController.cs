using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Services;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Notifications;
using TKMaster.ProjetoAulaAdilson.Core.Utilities;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.Mapper;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.Request.Cliente;
using TKMaster.ProjetoAulaAdilson.Core.WebApi.ViewModels.Responses;

namespace TKMaster.ProjetoAulaAdilson.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : APIController
    {
        #region Properties

        private readonly IClienteAppService _clienteAppService;

        #endregion

        #region Constructor

        public ClienteController(INotificationHandler<DomainNotification> notifications,
            IClienteAppService clienteAppService) : base(notifications)
        {
            _clienteAppService = clienteAppService;
        }

        #endregion

        #region Methods

        [HttpGet("ListarTodos")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ListarTodos()
        {
            var retorno = await _clienteAppService.ListarTodos();
            return Response(retorno.Select(x => x.ToResponse()));
        }

        [HttpGet("ObterPorCodigo/{codigo}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            var retorno = await _clienteAppService.ObterPorCodigo(codigo);
            return Response(retorno?.ToResponse());
        }

        [HttpPost("Adicionar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Adicionar([FromBody] RequestAdicionarCliente request)
        {
            return Response(await _clienteAppService.Adicionar(request.ToRequest()));
        }

        [HttpPut("Atualizar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Atualizar([FromBody] RequestAtualizarCliente request)
        {
            return Response(await _clienteAppService.Atualizar(request.ToRequest()));
        }

        [HttpPut("Excluir")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Excluir([FromBody] RequestReativarExcluirCliente request)
        {
            return Response(await _clienteAppService.Excluir(request.ToRequest()));
        }

        [HttpPut("Reativar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Reativar([FromBody] RequestReativarExcluirCliente request)
        {
            return Response(await _clienteAppService.Reativar(request.ToRequest()));
        }

        [HttpGet]
        [Route("NomeExiste/{nomeDoCliente}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> NomeExiste(string nomeDoCliente)
        {
            var conjunto = await _clienteAppService.NomeExiste(nomeDoCliente);
            return Response(conjunto?.ToResponse());
        }

        [HttpGet]
        [Route("DocumentoExiste/{documento}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> DocumentoExiste(string documento)
        {
            var conjunto = await _clienteAppService.DocumentoExiste(Util.RemoveNaoNumericos(documento));
            return Response(conjunto?.ToResponse());
        }

        #endregion
    }
}
