using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Domain.Model.Tarefas
{
    public class Tarefa : TarefaBase
    {
        public Tarefa(Guid id, string titulo, DateTime? dataConclusao)
            : base(id, titulo, dataConclusao)
        {

        }

        public Tarefa(string titulo)
            : base(titulo)
        {

        }
    }
}
