using DA.Alquileres.MonoProyecto.Data;
using DA.Alquileres.MonoProyecto.Model;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.MonoProyecto.Services
{
    public class TipoDocumentosServices : ITipoDocumentosServices
    {
        private readonly dbAlquileresContext context;

        public TipoDocumentosServices(dbAlquileresContext context)
        {
            this.context = context;
        }
        public async Task<TipoDocumentos> Create(TipoDocumentos entity)
        {
            context.tabTIPODOCUMENTOS.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Delete(int id)
        {
            var registros = 0;
            var entidadEliminar = await GetById(id);

            if (entidadEliminar == null) 
            {
                return registros;
            }

            context.tabTIPODOCUMENTOS.Remove(entidadEliminar);
            registros = await context.SaveChangesAsync();

            return registros;
        }

        public async Task<List<TipoDocumentos>?> GetAll()
        {
            return await context.tabTIPODOCUMENTOS.ToListAsync();
        }

        public async Task<TipoDocumentos?> GetById(object id)
        {
            var tipoDocumento = await context.tabTIPODOCUMENTOS.FindAsync(id);

            if (tipoDocumento != null)
            {
                context.Entry(tipoDocumento).State = EntityState.Detached;
            }

            return tipoDocumento;
        }

        public async Task<TipoDocumentos> Update(TipoDocumentos entity)
        {
            context.tabTIPODOCUMENTOS.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> PatchFechaDesactivacion(int id)
        {
            var entidad = context.tabTIPODOCUMENTOS.FirstOrDefault(u => u.Id == id);

            if (entidad == null)
            {
                return false;
            }

            entidad.FechaDesactivacion = DateTime.Now;
            context.tabTIPODOCUMENTOS.Update(entidad);
            await context.SaveChangesAsync();

            return true ;
        }
    }
}
