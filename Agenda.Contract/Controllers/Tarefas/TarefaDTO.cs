using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contract.Controllers.Tarefas
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Concluida { get; set; }

        public DateTime? DataConclusao { get; set; }
    }
}
