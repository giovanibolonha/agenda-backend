using Agenda.Core.Exceptions;
using Agenda.Core.Repository;
using Agenda.Core.Repository.Interfaces;
using Agenda.Data;
using Agenda.Data.DataModel;
using Agenda.Domain.Model.Tarefas;
using Agenda.Domain.Model.Tarefas.Interfaces;
using Agenda.Domain.Model.Tarefas.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda.Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AgendaContext _context;

        public TarefaRepository(AgendaContext context)
        {
            _context = context;
        }

        public void Add(ITarefa model)
        {
            var data = Mapper.Map<TarefaData>(model);

            data.OnAuditInsert(DateTime.Now);

            _context.Add(data);
        }

        public void Delete(Guid id)
        {
            var data = GetData(id);

            data.OnAuditDelete(DateTime.Now);

            _context.Update(data);
        }

        public ITarefa Get(Guid id)
        {
            var data = GetData(id);

            return Mapper.Map<ITarefa>(data);
        }

        public IEnumerable<ITarefa> GetAll()
        {
            return _context.Set<TarefaData>()
                .Where(x => !x.DeletedDate.HasValue)
                .ProjectTo<Tarefa>()
                .ToList();
        }

        public IPagedList<ITarefa> Paged(ITarefaParameter parameter)
        {
            var query = _context.Set<TarefaData>().Where(x => !x.DeletedDate.HasValue);

            if (!string.IsNullOrWhiteSpace(parameter.Titulo))
            {
                query = query.Where(x => x.Titulo.Contains(parameter.Titulo));
            }

            if (parameter.Concluida.HasValue)
            {
                if (parameter.Concluida.Value)
                {
                    query = query.Where(x => x.DataConclusao.HasValue);
                }
                else
                {
                    query = query.Where(x => !x.DataConclusao.HasValue);
                }
            }

            var count = query.Count();

            var models = query
                .OrderBy(x => x.Titulo)
                .Skip(parameter.PageSize * (parameter.PageNumber - 1))
                .Take(parameter.PageSize)
                .ProjectTo<Tarefa>()
                .ToList();

            return new PagedList<ITarefa>(models, count, parameter.PageNumber, parameter.PageSize);
        }

        public void Update(ITarefa model)
        {
            var data = GetData(model.Id);

            data.Titulo = model.Titulo;
            data.Descricao = model.Descricao;
            data.DataConclusao = model.DataConclusao;

            data.OnAuditUpdate(DateTime.Now);

            _context.Update(data);
        }

        private TarefaData GetData(Guid id)
        {
            var data = _context.Set<TarefaData>()
                .FirstOrDefault(x => x.Id == id && !x.DeletedDate.HasValue);

            return data != null ? data : throw new NotFoundException("Tarefa não encontrada");
        }
    }
}
