using Agenda.Application.Business.Interfaces.Tarefas;
using Agenda.Contract.Controllers.Tarefas;
using Agenda.Core.Repository;
using Agenda.Core.Repository.Interfaces;
using Agenda.Domain.Model.Tarefas;
using Agenda.Domain.Model.Tarefas.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda.Application.Business.Tarefas
{
    public class CadastroTarefaAppService : ICadastroTarefaAppService
    {
        public readonly ITarefaRepository _tarefaRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CadastroTarefaAppService(
            ITarefaRepository tarefaRepository, 
            IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(Guid id, TarefaForCreationDTO dto)
        {
            var model = _tarefaRepository.Get(id);

            model.Titulo = dto.Titulo;
            model.Descricao = dto.Descricao;

            _tarefaRepository.Update(model);

            _unitOfWork.Complete();
        }

        public void Cadastrar(TarefaForCreationDTO dto)
        {
            var model = new Tarefa(dto.Titulo);

            model.Descricao = dto.Descricao;

            _tarefaRepository.Add(model);

            _unitOfWork.Complete();
        }

        public void Concluir(Guid id)
        {
            var model = _tarefaRepository.Get(id);

            model.Concluir();

            _tarefaRepository.Update(model);

            _unitOfWork.Complete();
        }

        public void Reiniciar(Guid id)
        {
            var model = _tarefaRepository.Get(id);

            model.Reiniciar();

            _tarefaRepository.Update(model);

            _unitOfWork.Complete();
        }

        public void Excluir(Guid id)
        {
            _tarefaRepository.Delete(id);

            _unitOfWork.Complete();
        }

        public TarefaDTO Obter(Guid id)
        {
            var model = _tarefaRepository.Get(id);

            return Mapper.Map<TarefaDTO>(model);
        }

        public IPagedList<TarefaDTO> Paginar(ITarefaParameter parameter)
        {
            var paged = _tarefaRepository.Paged(parameter);

            return  Mapper.Map<PagedList<TarefaDTO>>(paged);
        }
    }
}
