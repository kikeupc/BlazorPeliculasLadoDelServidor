﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculasDelLadoDelServidor.DTOs
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
    }
}
