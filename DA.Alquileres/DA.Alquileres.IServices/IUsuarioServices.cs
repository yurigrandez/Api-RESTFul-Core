using DA.Alquileres.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.IServices
{
    public interface IUsuarioServices
    {
        Task<List<UsuarioDTO>?> GetAll();
        Task<UsuarioDTO?> GetById(object id);
        Task<UsuarioDTO> Create(UsuarioDTO entity);
        Task<UsuarioDTO?> Update(UsuarioDTO entity);
        Task<int> Delete(int id);
        Task<bool> PatchFechaDesactivacion(int id);
    }
}
