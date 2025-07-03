using DA.Alquileres.DTO.General;
using DA.Alquileres.Entidades.Entidades;
using DA.Alquileres.Entidades.Vistas;
using DA.Alquileres.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.Repository
{
    public class UsuarioRepository : BaseRepository<TabUsuarios>, IUsuarioRepository
    {
        private readonly _dbAlquileresContext context;

        public  UsuarioRepository(_dbAlquileresContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<List<AutoCompleteResponse>> GetAutoComplete(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericFilterResponse<VisUsuarios>> GetByFilter(GenericFilterRequest filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TabUsuarios>> GetLista()
        {
            return await context.TabUsuarios.ToListAsync();
        }

        public async Task<bool> PatchFechaDesactivacion(int id)
        {
            var usuarioBD = context.TabUsuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioBD == null)
            {
                return false;
            }

            usuarioBD.FechaDesactivacion = DateTime.Now;
            await SaveChange();

            return true;

        }

        public async Task<TabUsuarios?> Login(TabUsuarios usuario)
        {
            var usuarioLogin = await context.TabUsuarios.FirstOrDefaultAsync(x => x.Correo == usuario.Correo && x.Clave == usuario.Clave);
            return usuarioLogin;
        }
    }
}
