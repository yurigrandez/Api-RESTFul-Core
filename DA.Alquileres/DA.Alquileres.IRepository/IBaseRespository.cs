using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.IRepository
{
    /// <summary>
    /// Respositorio Base
    /// </summary>
    /// <typeparam name="T">Entidad genérica que representa a una tabla</typeparam>
    public interface IBaseRespository<T> :IDisposable where T : class
    {
        /// <summary>
        /// Representa un select * from T
        /// </summary>
        /// <returns>Obtiene todos los registros de una tabla</returns>
        Task<List<T>?> GetAll();

        /// <summary>
        /// Representa un select * from T where Id = id
        /// </summary>
        /// <param name="id">Llave primaria</param>
        /// <returns>retorna el registro que coincida con el id consultado</returns>
        Task<T?> GetById(object id);

        /// <summary>
        /// Representa un insert
        /// </summary>
        /// <param name="entity">nueva entidad que se va agregar a la bd</param>
        /// <returns>Retorna el registro insertado</returns>
        Task<T> Create(T entity);

        /// <summary>
        /// Representa un Update
        /// </summary>
        /// <param name="entity">Entidad que se va actualizar</param>
        /// <returns>Retorna el registro actualizado</returns>
        Task<T?> Update(T entity);

        /// <summary>
        /// Representa un delete
        /// </summary>
        /// <param name="id">Es la llave primaria del elemento que se va a eliminar</param>
        /// <returns>Retorna la cantidad de registros eliminados</returns>
        Task<int> Delete(int id);

        /// <summary>
        /// Método que se usará para guardar los cambios en la bd
        /// </summary>
        /// <returns>retorna el numero de filas afectadas</returns>
        Task<int> SaveChange();
    }
}
