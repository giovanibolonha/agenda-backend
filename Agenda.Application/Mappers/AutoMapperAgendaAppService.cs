using Agenda.Contract.Controllers.Tarefas;
using Agenda.Core.Repository;
using Agenda.Core.Repository.Interfaces;
using Agenda.Domain.Model.Tarefas.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Application.Mappers
{
    public class AutoMapperAgendaAppService
    {
        public static void RegisterMapping(IMapperConfigurationExpression map)
        {
            map.CreateMap<ITarefa, TarefaDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Titulo, y => y.MapFrom(z => z.Titulo))
                .ForMember(x => x.Descricao, y => y.MapFrom(z => z.Descricao))
                .ForMember(x => x.Concluida, y => y.MapFrom(z => z.Concluida))
                .ForMember(x => x.DataConclusao, y => y.MapFrom(z => z.DataConclusao));

            map.CreateMap<IPagedList<ITarefa>, PagedList<TarefaDTO>>()
                .ForCtorParam("items", x => x.MapFrom(y => y))
                .ForCtorParam("count", x => x.MapFrom(y => y.Count))
                .ForCtorParam("pageNumber", x => x.MapFrom(y => y.CurrentPage))
                .ForCtorParam("pageSize", x => x.MapFrom(y => y.PageSize));
        }
    }
}
