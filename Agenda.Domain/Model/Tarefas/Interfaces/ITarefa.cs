using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Domain.Model.Tarefas.Interfaces
{
    public interface ITarefa
    {
        Guid Id { get; }

        string Titulo { get; set; }

        string Descricao { get; set; }

        bool Concluida { get; }

        DateTime? DataConclusao { get; }

        void Concluir();

        void Reiniciar();
    }
}
