using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Alquileres.DTO.General
{
    public class GeneralResponseData<T> : GeneralResponse where T : class
    {
        public T? Data { get; set; }
    }
}
