using CastGroup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CastGroup.Domain.Interface.IService
{
    public interface ICursoService : IDisposable
    {
        Task<bool> Adicionar(Curso curso);
        Task Atualizar(Curso curso);
        Task Remover(int id);
        Task <List<Curso>> ObterTodos();
        Task<Curso> ObterPorId(int id);
        

    }
}
