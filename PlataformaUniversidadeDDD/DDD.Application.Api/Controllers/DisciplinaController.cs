using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.MemoryDb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        readonly IDisciplinaRepository _disciplinaRepository;

    public DisciplinaController(IDisciplinaRepository disciplinaRepository)     
    { 
        _disciplinaRepository= disciplinaRepository;
    }

        // GET: api/<DisciplinaController>
        [HttpGet]

        public ActionResult<List<Disciplina>> Get()
        {
            return Ok(_disciplinaRepository.GetDisciplinas());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Disciplina> GetById(int id)
        {
            return Ok(_disciplinaRepository.GetDisciplinaById(id));
        }

        [HttpPost]
        public ActionResult<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            _disciplinaRepository.InsertDisciplina(disciplina);
            return CreatedAtAction(nameof(GetById), new { id = disciplina.DisciplinaId }, disciplina);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Disciplina disciplina)
        {
            try
            {
                if (disciplina == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.UpdateDisciplina(disciplina);
                return Ok("Disciplina atualizada com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.DeleteDisciplina(id);
                return Ok("Disciplina deletada com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
