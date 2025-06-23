using DA.Alquileres.MonoProyecto.Model;
using DA.Alquileres.MonoProyecto.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DA.Alquileres.MonoProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentosController : ControllerBase
    {
        private readonly ITipoDocumentosServices services;

        public TipoDocumentosController(ITipoDocumentosServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentos>>> GetAll()
        {
            var tipoDocumentos = await services.GetAll();

            return Ok(tipoDocumentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentos>> GetById(int id)
        {
            var tipoDocumento = await services.GetById(id);

            return Ok(tipoDocumento);

        }

        [HttpPost]
        public async Task<ActionResult<TipoDocumentos>> Create([FromBody] TipoDocumentos tipoDocumentos)
        {
            var tipoDocumentoBD = await services.Create(tipoDocumentos);
            return Ok(tipoDocumentoBD);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoDocumentos>> Put(int id, TipoDocumentos tipoDocumentos)
        {
            var tipoDocumentoBD = await services.GetById(id);

            if(tipoDocumentoBD == null)
            {
                return BadRequest();
            }

            await services.Update(tipoDocumentos);

            return Ok(tipoDocumentos);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var registros = await services.Delete(id);

            return Ok(registros);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Patch(int id)
        {
            var resultado = await services.PatchFechaDesactivacion(id);
            return resultado;
        }
    }
}
