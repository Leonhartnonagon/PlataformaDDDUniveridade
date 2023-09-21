using DDD.Domain;
using DDD.Infra.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly SqlContext _context;

        public MatriculaRepository(SqlContext context)
        {
            _context = context;
        }

        public Aluno InsertDisciplinasOnAluno(List<Disciplina> disciplinas)
        {
            //Função de inserir Multiplas disciplinas em um aluno aqui!
            return null;
           
        }
    }
}
