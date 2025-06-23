using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.General
{
    public class AutoCompleteResponse
    {
        /// <summary>
        /// Contiene el Id del objeto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Texto que se mostrará en el autocomplete
        /// </summary>
        public string? Text { get; set; }
    }
}
