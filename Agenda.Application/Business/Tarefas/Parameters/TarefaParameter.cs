using Agenda.Core.Repository;
using Agenda.Domain.Model.Tarefas.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Application.Business.Parameters.Tarefas
{
    public class TarefaParameter : ParameterBase, ITarefaParameter
    {
        public string Titulo { get; set; }

        public bool? Concluida { get; set; }
    }
}
