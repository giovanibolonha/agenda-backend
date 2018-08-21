using Agenda.IoC;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Web.Api.Configurations
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AgendaModule());
        }
    }
}
