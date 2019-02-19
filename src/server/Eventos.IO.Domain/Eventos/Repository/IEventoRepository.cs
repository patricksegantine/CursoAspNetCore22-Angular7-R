﻿using Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos.Repository
{
    public interface IEventoRepository : IRepository<Evento>
    {
        // Posso colocar demais métodos especializados
        // ObterEnderecoPorEvento
        // ObterEventoPorCidade

        IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);

        Endereco ObterEnderecoPorId(Guid id);

        void IncluirEndereco(Endereco endereco);

        void AtualizarEndereco(Endereco endereco);

        IEnumerable<Categoria> ObterCategorias();
    }
}
