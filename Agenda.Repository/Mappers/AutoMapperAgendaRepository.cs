using Agenda.Data.DataModel;
using Agenda.Domain.Model.Tarefas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Repository.Mappers
{
    public class AutoMapperAgendaRepository
    {
        public static void RegisterMapping(IMapperConfigurationExpression map)
        {
            map.CreateMap<TarefaData, Tarefa>()
                .ForCtorParam("id", x => x.MapFrom(y => y.Id))
                .ForCtorParam("titulo", x => x.MapFrom(y => y.Titulo))
                .ForCtorParam("dataConclusao", x => x.MapFrom(y => y.DataConclusao))
                .ForMember(x => x.Descricao, y => y.MapFrom(z => z.Descricao));

            map.CreateMap<Tarefa, TarefaData>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Titulo, y => y.MapFrom(z => z.Titulo))
                .ForMember(x => x.DataConclusao, y => y.MapFrom(z => z.DataConclusao))
                .ForMember(x => x.Descricao, y => y.MapFrom(z => z.Descricao));
        }
    }
}
