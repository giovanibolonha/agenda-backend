using Agenda.Domain.Model.Tarefas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Domain.Model.Tarefas
{
    public abstract class TarefaBase : ITarefa
    {
        public TarefaBase(Guid id, string titulo, DateTime? dataConclusao)
        {
            Id = id;
            Titulo = titulo;
            DataConclusao = dataConclusao;
        }

        public TarefaBase(string titulo)
            : this(Guid.NewGuid(), titulo, null)
        {

        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }

            private set { _id = value != Guid.Empty ? value : throw new Exception("Id inválido"); }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }

            set { _titulo = !string.IsNullOrWhiteSpace(value) ? value : throw new Exception("Título Obrigatório"); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }

            set { _descricao = value; }
        }

        public bool Concluida
        {
            get { return DataConclusao.HasValue; }
        }

        private DateTime? _dataConclusao;
        public DateTime? DataConclusao
        {
            get { return _dataConclusao; }

            private set
            {
                _dataConclusao = value;
            }
        }
        public void Concluir()
        {
            DataConclusao = !Concluida
                ? DateTime.Now
                : throw new Exception("A tarefa já está concluída");
        }

        public void Reiniciar()
        {
            DataConclusao = Concluida
                ? (DateTime?)null
                : throw new Exception("A tarefa não está concluída");
        }
    }
}
