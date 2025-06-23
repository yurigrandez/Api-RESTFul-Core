using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.General
{
    public class GeneralResponse
    {
        /// <summary>
        /// Indica si la operacion fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Indica si se debe mostrar alguna alerta en el front
        /// </summary>
        public bool ShowAlert { get; set; }

        /// <summary>
        /// Título que llevara la alerta
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Mensaje que se mostrara como respuesta
        /// </summary>
        public string? Mensaje { get; set; }

    }
}
