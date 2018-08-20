using Agenda.Core.Repository.Interfaces;
using Agenda.Domain.Model.Tarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Domain.Model.Tarefas.Repositories
{
    public interface ITarefaRepository : IRepository<ITarefa>
    {
        IPagedList<ITarefa> Paged(ITarefaParameter parameter);
    }
}
