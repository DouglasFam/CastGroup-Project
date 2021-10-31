using CastGroup.Domain.Models;
using CastGroup.Domain.Interface.IRepository;
using CastGroup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CastGroup.Infra.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository 
    {
        public CursoRepository(ApiDbContext context) : base(context) { }

        public async Task<Curso> VerificaPeriodoCurso(DateTime dataInicio, DateTime dataFim)
        {
            var curso = Db.Cursos.FirstOrDefaultAsync();

            if (curso.Result == null) return await curso;


             var data = await Db.Cursos.AsNoTracking().FirstOrDefaultAsync(c =>
            (c.DataInicio <= dataInicio && c.DataFim >= dataInicio) ||
            (c.DataInicio <= dataFim && c.DataFim >= dataInicio));

            return data;

        }

        public async Task<Curso> ObterCursoPorId(int id)
        {
            return await 
                 Db.Cursos.AsNoTracking()
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
