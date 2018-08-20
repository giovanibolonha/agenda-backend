using Agenda.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Domain.Model.Tarefas.Repositories
{
    public interface ITarefaParameter : IParameter
    {
        string Titulo { get; set; }

        bool? Concluida { get; set; }
    }
}
