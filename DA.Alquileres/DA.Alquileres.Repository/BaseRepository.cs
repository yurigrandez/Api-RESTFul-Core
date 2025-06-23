using DA.Alquileres.Entidades.Entidades;
using DA.Alquileres.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.Repository
{
    public class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        private readonly _dbAlquileresContext context;
        private DbSet<T> dbSet;

        public BaseRepository(_dbAlquileresContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChange();
            return entity;
        }

        public virtual async Task<int> Delete(int id)
        {
            int registros = 0;

            //buscando el registro
            T? entidadBD = await GetById(id);

            //validando si se encontró el registro
            if (entidadBD == null)
            {
                return registros;
            }

            //eliminando registro
            dbSet.Remove(entidadBD!);
            registros = await SaveChange();

            return registros;

        }

        public virtual async Task<List<T>?> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetById(object id)
        {
            //return await dbSet.FindAsync(id);

            var entity = await dbSet.FindAsync(id);

            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        } 

        public virtual async Task<int> SaveChange()
        {
            return await context.SaveChangesAsync();
        }

        public virtual async Task<T?> Update(T entity)
        {
            dbSet.Update(entity);
            await SaveChange();
            return entity;
        }
    }
}
