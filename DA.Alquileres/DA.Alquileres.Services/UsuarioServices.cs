using AutoMapper;
using DA.Alquileres.DTO.Usuario;
using DA.Alquileres.Entidades.Entidades;
using DA.Alquileres.IRepository;
using DA.Alquileres.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository repository;
        private readonly IMapper mapper;

        public UsuarioServices(IUsuarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UsuarioDTO> Create(UsuarioDTO entity)
        {
            //mapeand entidad
            var entidadBD = mapper.Map<TabUsuarios>(entity);
            var entidadCreadaBD = await repository.Create(entidadBD);
            var entidadCreadaDTO = mapper.Map<UsuarioDTO>(entidadCreadaBD);

            return entidadCreadaDTO;
        }

        public async Task<int> Delete(int id)
        {
            int registros = 0;
            var entidadEliminar = await repository.GetById(id);

            if (entidadEliminar == null)
            { 
                return registros;
            }

            registros = await repository.Delete(id);

            return registros;
        }

        public async Task<List<UsuarioDTO>?> GetAll()
        {
            List<UsuarioDTO> usuariosDTO = new();
            List<TabUsuarios>? usuariosBD = await repository.GetAll();

            usuariosDTO = mapper.Map<List<UsuarioDTO>>(usuariosBD);

            return usuariosDTO;
        }

        public async Task<UsuarioDTO?> GetById(object id)
        {
            var usuarioBD = await repository.GetById(id);
            var usuarioEncontrado = mapper.Map<UsuarioDTO?>(usuarioBD);
            return usuarioEncontrado;
        }

        public async Task<bool> PatchFechaDesactivacion(int id)
        {
            var resultado = await repository.PatchFechaDesactivacion(id);
            return resultado;
        }

        public async Task<UsuarioDTO?> Update(UsuarioDTO entity)
        {
            var usuarioActualizar = mapper.Map<TabUsuarios>(entity);
            var usuarioActualizado = await repository.Update(usuarioActualizar);
            var usuarioBD = mapper.Map<UsuarioDTO>(usuarioActualizado);

            return usuarioBD;
        }

        public async Task<List<UsuarioDTO>> GetLista()
        {
            var listaDTO = new List<UsuarioDTO>();
            var listaBD = await repository.GetLista();

            listaDTO = mapper.Map<List<UsuarioDTO>>(listaBD);

            return listaDTO;
        }

        public async Task<UsuarioLoginResponseDTO?> Login(UsuarioLoginRequestDTO usuario)
        {
            var usuarioRequest = mapper.Map<TabUsuarios>(usuario);
            var usuarioResponse = await repository.Login(usuarioRequest);
            
            if(usuarioResponse == null)
                return null;

            var usuarioLogin = mapper.Map<UsuarioLoginResponseDTO>(usuarioResponse);

            return usuarioLogin;
        }
    }
}
