using Agenda.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Data.DataModel
{
    public class TarefaData : AuditEntityDataBase<Guid>
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataConclusao { get; set; }
    }
}
