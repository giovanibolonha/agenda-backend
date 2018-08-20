using Agenda.Domain.Model.Tarefas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Agenda.UnitTest.Domain.Model.Tarefas
{
    public class TarefaTest
    {
        [Fact]
        public void Nova()
        {
            string titulo = "titulo";
            string descricao = "descricao";

            var tarefa = new Tarefa(titulo);

            tarefa.Descricao = descricao;

            Assert.NotEqual(tarefa.Id, Guid.Empty);
            Assert.Equal(tarefa.Titulo, titulo);
            Assert.Equal(tarefa.Descricao, descricao);
            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
        }

        [Fact]
        public void Atualizar()
        {
            string titulo = "titulo";
            string descricao = "descricao";

            var tarefa = new Tarefa("teste")
            {
                Descricao = "teste"
            };

            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;

            Assert.Equal(tarefa.Titulo, titulo);
            Assert.Equal(tarefa.Descricao, descricao);
        }

        [Fact]
        public void Concluir()
        {
            var tarefa = new Tarefa("titulo");

            tarefa.Concluir();

            Assert.True(tarefa.Concluida);
            Assert.NotNull(tarefa.DataConclusao);
        }

        [Fact]
        public void Reiniciar()
        {
            var tarefa = new Tarefa("titulo");

            tarefa.Concluir();

            tarefa.Reiniciar();

            Assert.False(tarefa.Concluida);
            Assert.Null(tarefa.DataConclusao);
        }
    }
}
