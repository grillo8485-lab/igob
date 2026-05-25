using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class Carta
    {
        public int IdCarta = int.MinValue;
        public int IdEstatus = int.MinValue;
        public int IdTipoSolicitud = int.MinValue;
        public int Numero = int.MinValue;
        public string Inciso = string.Empty;
        public string NombreCarta = string.Empty;
        public string Descripcion = string.Empty;
        public string CartaTexto = string.Empty;
        public int Activo = int.MinValue;

        public int IdProveedorCarta = int.MinValue;
        public int IdProveedorRqInvitacion = int.MinValue;
        public bool AceptacionCarta = false;
        public DateTime FechaAceptacion = DateTime.MinValue;

    }
}