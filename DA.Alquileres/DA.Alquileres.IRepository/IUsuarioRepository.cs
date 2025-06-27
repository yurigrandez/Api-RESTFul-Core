using DA.Alquileres.DTO.General;
using DA.Alquileres.Entidades.Entidades;
using DA.Alquileres.Entidades.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.IRepository
{
    public interface IUsuarioRepository : IBaseRespository<TabUsuarios>
    {
        Task<GenericFilterResponse<VisUsuarios>> GetByFilter(GenericFilterRequest filter);
        Task<List<AutoCompleteResponse>> GetAutoComplete(string query);
        Task<bool> PatchFechaDesactivacion(int id);
        Task<List<TabUsuarios>> GetLista();
    }
}
