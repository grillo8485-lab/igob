using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beTmpRequisicionesLicitacion
    {

        public string IdGuid { get; set; }
        public int IdRequisicion { get; set; }
        public int IdTiempo { get; set; }
        public decimal Total { get; set; }
        public int IdConfiguracionModalidad { get; set; }

        public beTmpRequisicionesLicitacion()
        {

        }

        public beTmpRequisicionesLicitacion(string pIdGuid, int pIdRequisicion, int pIdTiempo, decimal pTotal)
        {
            this.IdGuid = pIdGuid;
            this.IdRequisicion = pIdRequisicion;
            this.IdTiempo = pIdTiempo;
            this.Total = pTotal;
        }


    }
}
