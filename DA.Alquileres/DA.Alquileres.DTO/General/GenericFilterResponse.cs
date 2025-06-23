using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.General
{
    public class GenericFilterResponse<T>
    {
        public int TotalRegistrfos { get; set; }
        public List<T>? Registros { get; set; } = new List<T>();

    }
}
