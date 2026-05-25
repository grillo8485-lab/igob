using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClavesPresupuestales
    {
        public string OrigenRecurso = string.Empty;
        public string ClavesPresupuestal = string.Empty;
        public string NumeroMinistracion = string.Empty;
        public string De = string.Empty;
        public string Al = string.Empty;
        public decimal MontoPresupuestado = decimal.MinValue;
    }
}