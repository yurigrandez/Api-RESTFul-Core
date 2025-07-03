using AutoMapper;
using DA.Alquileres.DTO.General;
using DA.Alquileres.DTO.Usuario;
using DA.Alquileres.Entidades.Entidades;
using DA.Alquileres.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA.Alquileres.API.Controllers
{
    /// <summary>
    /// Controlador de la clase Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices services;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services">representa a la clase que contiene las reglas del negocio</param>
        /// <param name="mapper">clase para el mapeo de los DTO</param>
        public UsuarioController(IUsuarioServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        /// <summary>
        /// Obtiene la lista de usuarios registraados
        /// </summary>
        /// <returns>muestra una lista</returns>
        [HttpGet]
        public async Task<ActionResult<GeneralResponseListData<UsuarioDTO>>> GetAll()
        {
            List<UsuarioDTO>? lista = await services.GetAll();

            var respuesta = new GeneralResponseListData<UsuarioDTO>();
            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "GetAll";
            respuesta.Mensaje = "Lista de usuarios";
            respuesta.Data = lista;

            return Ok(respuesta);
        }

        /// <summary>
        /// Lista los usuarios
        /// </summary>
        /// <returns>Muestra la lista de usuarios directamente</returns>
        [HttpGet("GetLista")]
        [Authorize]
        public async Task<ActionResult<List<UsuarioDTO>>> GetLista()
        {
            List<UsuarioDTO>? lista = await services.GetLista();

            return Ok(lista);
        }

        /// <summary>
        /// Busqueda de un usuario específico
        /// </summary>
        /// <param name="id">Llave primaria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var respuesta = new GeneralResponseData<UsuarioDTO>();
            var usuarioEncontrado = await services.GetById(id);

            if (usuarioEncontrado == null)
            {
                respuesta.Success = true;
                respuesta.ShowAlert = false;
                respuesta.Title = "GetById";
                respuesta.Mensaje = "No se encontró resultados";
                respuesta.Data = null;

                return Ok(respuesta);
            }

            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "GetById";
            respuesta.Mensaje = "Registro encontrado";
            respuesta.Data = usuarioEncontrado;

            return Ok(respuesta);

        }

        /// <summary>
        /// Creacion de un nuevo usuario
        /// </summary>
        /// <param name="usuario">datos del nuevo usuario a crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GeneralResponseData<UsuarioDTO>>> Create(UsuarioNuevoDTO usuario)
        {
            var usuarioGrabar = mapper.Map<UsuarioDTO>(usuario);
            var usuarioGrabado = await services.Create(usuarioGrabar);

            var respuesta = new GeneralResponseData<UsuarioDTO>();
            respuesta.Success = true;
            respuesta.ShowAlert = true;
            respuesta.Title = "Create";
            respuesta.Mensaje = "Nuevo usuario";
            respuesta.Data = usuarioGrabado;

            return Ok(respuesta);
        }

        /// <summary>
        /// Actualización de un usuario
        /// </summary>
        /// <param name="usuario">Datos a actualizar del usuario</param>
        /// <param name="id">Llave primaria</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponseData<UsuarioDTO>>> Update([FromBody] UsuarioActualizarDTO usuario, int id)
        {
            var respuesta = new GeneralResponseData<UsuarioDTO>();
            var usuarioBuscado = await services.GetById(id);

            if (usuario == null)
            {
                respuesta.Success = false;
                respuesta.ShowAlert = true;
                respuesta.Title = "Update";
                respuesta.Mensaje = "Ingrese datos";
                respuesta.Data = null;

                return BadRequest(respuesta);
            }

            if (usuarioBuscado == null)
            {
                respuesta.Success = true;
                respuesta.ShowAlert = false;
                respuesta.Title = "Update";
                respuesta.Mensaje = "No se encontró resultados";
                respuesta.Data = null;

                return Ok(respuesta);
            }

            usuarioBuscado.Nombre = usuario.Nombre;
            usuarioBuscado.Paterno = usuario.Paterno;
            usuarioBuscado.Materno = usuario.Materno;
            usuarioBuscado.Correo = usuario.Correo;
            usuarioBuscado.Clave = usuario.Clave;
            usuarioBuscado.IdTipoUsuario = usuario.IdTipoUsuario;
            usuarioBuscado.IdtipoDocumento = usuario.IdtipoDocumento;
            usuarioBuscado.NumeroDocumento = usuario.NumeroDocumento;
            usuarioBuscado.Direccion = usuario.Direccion;
            usuarioBuscado.Telefono = usuario.Telefono;

            var usuarioActualizar = mapper.Map<UsuarioDTO>(usuarioBuscado);
            usuarioActualizar.FechaModificacion = DateTime.Now;

            var usuarioActualizado = await services.Update(usuarioActualizar);
            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "Update";
            respuesta.Mensaje = "Registro actualizado";
            respuesta.Data = usuarioActualizado;

            return Ok(respuesta);

        }

        /// <summary>
        /// Eliminación de un usuario
        /// </summary>
        /// <param name="id">Llave primaria</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralResponse>> Delete(int id)
        {
            var respuesta = new GeneralResponse();
            int registros = await services.Delete(id);

            if (registros == 0)
            {
                respuesta.Success = true;
                respuesta.ShowAlert = false;
                respuesta.Title = "Delete";
                respuesta.Mensaje = "No se encontró registros para eliminar";

                return Ok(respuesta);
            }

            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "Delete";
            respuesta.Mensaje = $"Se elminó {registros} registros";

            return Ok(respuesta);
        }

        /// <summary>
        /// Actualización parcial de un usuario
        /// </summary>
        /// <param name="usuario">Datos a actualizar de un usuario</param>
        /// <param name="id">Llave primaria</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<GeneralResponse>> Patch([FromBody] UsuarioActualizarDTO usuario, int id)
        {
            var respuesta = new GeneralResponse();

            if (usuario == null)
            {
                respuesta.Success = false;
                respuesta.ShowAlert = true;
                respuesta.Title = "Patch";
                respuesta.Mensaje = "Ingrese datos";

                return BadRequest(respuesta);
            }

            bool resultado = await services.PatchFechaDesactivacion(id);

            respuesta.Success = true;
            respuesta.ShowAlert = false;
            respuesta.Title = "Patch";
            respuesta.Mensaje = (resultado?"Registro desactivado":"No se desactivo el registro");

            return Ok(respuesta);

        }



    }
}
