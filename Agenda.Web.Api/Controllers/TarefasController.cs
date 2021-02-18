using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.Business.Interfaces.Tarefas;
using Agenda.Application.Business.Parameters.Tarefas;
using Agenda.Contract.Controllers.Tarefas;
using Agenda.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Agenda.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Tarefas")]
    public class TarefasController : Controller
    {
        private readonly ICadastroTarefaAppService _cadastroTarefaAppService;

        public TarefasController(ICadastroTarefaAppService cadastroTarefaAppService)
        {
            _cadastroTarefaAppService = cadastroTarefaAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]TarefaParameter parameter)
        {
            try
            {
                var paginacao = _cadastroTarefaAppService.Paginar(parameter);

                HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginacao.CreateMetaData()));

                return Ok(paginacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var dto = _cadastroTarefaAppService.Obter(id);

                return Ok(dto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]TarefaForCreationDTO dto)
        {
            try
            {
                _cadastroTarefaAppService.Cadastrar(dto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]TarefaForCreationDTO dto)
        {
            try
            {
                _cadastroTarefaAppService.Atualizar(id, dto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/concluir")]
        public IActionResult PatchConcluir(Guid id)
        {
            try
            {
                _cadastroTarefaAppService.Concluir(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/reiniciar")]
        public IActionResult PatchReiniciar(Guid id)
        {
            try
            {
                _cadastroTarefaAppService.Reiniciar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _cadastroTarefaAppService.Excluir(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}