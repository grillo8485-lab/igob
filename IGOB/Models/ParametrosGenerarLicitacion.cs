using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ParametrosGenerarLicitacion
    {
        public List<int> id { get; set; }
        public int IdLicitacion { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public int IdTipoLicitacion { get; set; }
        public  int IdTiempo { get; set; }
        public int IdModalidadLicitacion { get; set; }
    }
}