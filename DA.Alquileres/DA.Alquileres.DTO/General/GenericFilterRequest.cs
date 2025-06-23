using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.General
{
    public class GenericFilterRequest
    {
        public int Pagina { get; set; }
        public int Cantidad { get; set; }

        public List<ItemFilterRequest>? Filtro { get; set; } = new List<ItemFilterRequest>();
    }

    public class ItemFilterRequest
    {
        public string? Nombre { get; set; }
        public string? Valor { get; set; }
    }
}
