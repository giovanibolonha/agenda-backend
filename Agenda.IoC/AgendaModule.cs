using Agenda.Application.Business.Interfaces.Tarefas;
using Agenda.Application.Business.Tarefas;
using Agenda.Core.Repository.Interfaces;
using Agenda.Domain.Model.Tarefas.Repositories;
using Agenda.Repository.Repositories;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.IoC
{
    public class AgendaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<TarefaRepository>().As<ITarefaRepository>();
            builder.RegisterType<CadastroTarefaAppService>().As<ICadastroTarefaAppService>();
        }
    }
}
