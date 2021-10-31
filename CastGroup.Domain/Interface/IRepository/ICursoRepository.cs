using CastGroup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CastGroup.Domain.Interface.IRepository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso> VerificaPeriodoCurso(DateTime dataInicio, DateTime dataFim);
        Task<Curso> ObterCursoPorId(int id);
    }
}
