using DA.Alquileres.MonoProyecto.Model;
using Microsoft.EntityFrameworkCore;

namespace DA.Alquileres.MonoProyecto.Data
{
    public class dbAlquileresContext : DbContext
    {
        public dbAlquileresContext()
        {
        }

        public dbAlquileresContext(DbContextOptions<dbAlquileresContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TipoDocumentos> tabTIPODOCUMENTOS { get; set; }
    }
}
