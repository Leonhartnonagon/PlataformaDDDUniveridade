using DDD.Domain;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly SqlContext _context;
        //Dependency Injection
        public AlunoRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Aluno> GetAlunos()
        {
          var List = _context.Alunos.Include(x => x.Disciplinas).ToList();
            return List;
        }

        public Aluno GetAlunoById(int id)
        {
            return _context.Alunos.Find(id);
        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAluno(int id)
        {
            try
            {
                var aluno = _context.Alunos.Find(id);
                _context.Set<Aluno>().Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State= EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
