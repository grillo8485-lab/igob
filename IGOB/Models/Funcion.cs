using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class Funcion
    {
        public int IdFuncion = int.MinValue;
        public int IdModulo = int.MinValue;
        public string Descripcion = string.Empty;
        public bool ActivoMenu = false;
        public bool btnNuevo = false;
        public bool btnEditar = false;
        public bool btnEliminar = false;
        public bool btnConsultar = false;
    }
}