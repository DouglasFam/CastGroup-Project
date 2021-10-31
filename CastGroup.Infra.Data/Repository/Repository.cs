using CastGroup.Domain.Models;
using CastGroup.Domain.Interface.IRepository;
using CastGroup.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CastGroup.Infra.Data.Repository
{
   public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApiDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity tentity)
        {
            DbSet.Add(tentity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            try
            {
                var entry = Db.Cursos.Find(entity.Id);

                Db.Entry(entry).CurrentValues.SetValues(entity);

                Db.ChangeTracker.Clear();
                DbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task Remover(int id)
        {
            var entity = await ObterPorId(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }
              
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
