using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculasDelLadoDelServidor.DTOs
{
    public class RespuestaPaginada<T>
    {
        public int TotalPaginas { get; set; }
        public List<T> Registros { get; set; }
    }
}
