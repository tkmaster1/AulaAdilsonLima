﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.ProjetoAulaAdilson.Core.Domain.Entities;

namespace TKMaster.ProjetoAulaAdilson.Core.Domain.Interfaces.Services
{
    public interface IClienteAppService : IDisposable
    {
        Task<IEnumerable<Cliente>> ListarTodos();

        Task<Cliente> ObterPorCodigo(int codigo);

        Task<int> Adicionar(Cliente entity);

        Task<bool> Atualizar(Cliente entity);

        Task<bool> Excluir(Cliente entity);

        Task<bool> Reativar(Cliente entity);

        Task<Cliente> NomeExiste(string nomeDoCliente);

        Task<Cliente> DocumentoExiste(string documento);
    }
}
