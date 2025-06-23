using DA.Alquileres.MonoProyecto.Model;

namespace DA.Alquileres.MonoProyecto.Services
{
    public interface ITipoDocumentosServices
    {
        /// <summary>
        /// Representa un select * from T
        /// </summary>
        /// <returns>Obtiene todos los registros de una tabla</returns>
        Task<List<TipoDocumentos>?> GetAll();

        /// <summary>
        /// Representa un select * from T where Id = id
        /// </summary>
        /// <param name="id">Llave primaria</param>
        /// <returns>retorna el registro que coincida con el id consultado</returns>
        Task<TipoDocumentos?> GetById(object id);

        /// <summary>
        /// Representa un insert
        /// </summary>
        /// <param name="entity">nueva entidad que se va agregar a la bd</param>
        /// <returns>Retorna el registro insertado</returns>
        Task<TipoDocumentos> Create(TipoDocumentos entity);

        /// <summary>
        /// Representa un Update
        /// </summary>
        /// <param name="entity">Entidad que se va actualizar</param>
        /// <returns>Retorna el registro actualizado</returns>
        Task<TipoDocumentos> Update(TipoDocumentos entity);

        /// <summary>
        /// Representa un delete
        /// </summary>
        /// <param name="id">Es la llave primaria del elemento que se va a eliminar</param>
        /// <returns>Retorna la cantidad de registros eliminados</returns>
        Task<int> Delete(int id);

        /// <summary>
        /// Actualizacion parcial de la entidad
        /// </summary>
        /// <param name="id">Llave primaria</param>
        /// <param name="fechaDesactivacion">Valor actualizar</param>
        /// <returns></returns>
        Task<bool> PatchFechaDesactivacion(int id);
    }
}
