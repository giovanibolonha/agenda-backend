using Agenda.Contract.Controllers.Tarefas;
using Agenda.Core.Repository.Interfaces;
using Agenda.Domain.Model.Tarefas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Application.Business.Interfaces.Tarefas
{
    public interface ICadastroTarefaAppService
    {
        void Atualizar(Guid id, TarefaForCreationDTO dto);

        void Cadastrar(TarefaForCreationDTO dto);

        void Concluir(Guid id);

        void Excluir(Guid id);

        TarefaDTO Obter(Guid id);

        IPagedList<TarefaDTO> Paginar(ITarefaParameter parameter);

        void Reiniciar(Guid id);
    }
}
