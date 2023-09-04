using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_alunoRepository.GetAlunos());

        }
        
        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_alunoRepository.GetAlunoById(id));
        }

        [HttpPost]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Aluno aluno) 
        {
            try
            {
                if(aluno == null)
                {
                    return BadRequest();
                }
                _alunoRepository.UpdateAluno(aluno);
                return Ok("Aluno atualizado com sucesso");
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
                _alunoRepository.DeleteAluno(id);
                return Ok("Aluno deletado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
