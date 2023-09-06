using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class Matricula
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public DateTime data;
    }
}
