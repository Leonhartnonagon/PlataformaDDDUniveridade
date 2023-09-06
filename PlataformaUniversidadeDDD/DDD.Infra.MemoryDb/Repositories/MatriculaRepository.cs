using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApiContext _context;

        public MatriculaRepository(ApiContext context)
        {
            _context = context;
        }

        public Aluno InsertDisciplinasOnAluno(List<Disciplina> disciplinas)
        {
           //Função de inserir Multiplas disciplinas em um aluno aqui!
           
        }
    }
}
