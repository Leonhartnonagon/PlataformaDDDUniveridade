using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.MemoryDb.Repositories;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        readonly IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpPut]
        public ActionResult Matricular([FromBody] List<Disciplina> disciplinas)
        {
            try
            {
                if (disciplinas == null)
                {
                    return BadRequest();
                }
                _matriculaRepository.InsertDisciplinasOnAluno(disciplinas);
                return Ok("Aluno matriculado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
