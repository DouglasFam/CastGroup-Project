using CastGroup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CastGroup.Domain.Interface.IRepository
{
    public interface IRepository<Tentity> : IDisposable where Tentity : Entity
    {
        Task Adicionar(Tentity entity);
        Task Atualizar(Tentity entity);
        Task Remover(int id);
        Task<Tentity> ObterPorId(int id);
        Task<List<Tentity>> ObterTodos();
        Task<int> SaveChanges();
    }
}
