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
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly SqlContext _context;
        public DisciplinaRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Disciplina> GetDisciplinas()
        {
            var List = _context.Disciplinas.ToList();
            return List;
        }

        public Disciplina GetDisciplinaById(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public void InsertDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            _context.Entry(disciplina).State= EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDisciplina(int id)
        {
            try
            {
                var disciplina = _context.Disciplinas.Find(id);
                _context.Set<Disciplina>().Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception exc)
            {

                throw;
            }
        }
    }
}
