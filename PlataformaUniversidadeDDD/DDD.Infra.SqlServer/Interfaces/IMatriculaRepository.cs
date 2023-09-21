﻿using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IMatriculaRepository
    {
        public Aluno InsertDisciplinasOnAluno(List<Disciplina> disciplinas);
    }
}
