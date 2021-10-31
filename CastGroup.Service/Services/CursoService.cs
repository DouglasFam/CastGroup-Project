using CastGroup.Domain.Models;
using CastGroup.Domain.Interface.IRepository;
using CastGroup.Domain.Interface.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CastGroup.Service.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<Curso>> ObterTodos()
        {
           return await _cursoRepository.ObterTodos();
        }

        public async Task<Curso> ObterPorId(int id)
        {
          return  await _cursoRepository.ObterPorId(id);
        }
        public async Task<bool> Adicionar(Curso curso)
        {
           var periodoCurso =  _cursoRepository.VerificaPeriodoCurso(curso.DataInicio, curso.DataFim);

            if(periodoCurso == null)
            {
                await _cursoRepository.Adicionar(curso);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task Atualizar(Curso curso)
        {
            await _cursoRepository.Atualizar(curso);
        }

        public async Task Remover(int id)
        {
            await _cursoRepository.Remover(id);
        }

        public void Dispose()
        {
            _cursoRepository?.Dispose();
        }

       
    }
}
