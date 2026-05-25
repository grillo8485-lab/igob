using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beRequisicionesCondicionesEntregas
    {

        public int IdRequisicionCondicionEntrega { get; set; }
        public int IdRequisicion { get; set; }
        public int IdTipoDia { get; set; }
        public int IdPlazoEntegra { get; set; }
        public int PlazoEntregaCantidad { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IdTipoEntrega { get; set; }
        public string Observaciones { get; set; }
        public string NotaEspecial { get; set; }
        public int IdEstatus { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPlazoTiempo { get; set; }
        public bool IsNUll { get; set; }

        public beRequisicionesCondicionesEntregas()
        {
            this.IsNUll = true;
        }

        public beRequisicionesCondicionesEntregas(int pIdRequisicionCondicionEntrega, int pIdRequisicion, int pIdTipoDia, int pIdPlazoEntegra, int pPlazoEntregaCantidad, DateTime pFechaLimite, int pIdTipoEntrega, string pObservaciones, string pNotaEspecial, int pIdEstatus, int pIdUsuarioRegistro, DateTime pFechaRegistro, int pIdPlazoTiempo,bool pIsNUll)
        {
            this.IdRequisicionCondicionEntrega = pIdRequisicionCondicionEntrega;
            this.IdRequisicion = pIdRequisicion;
            this.IdTipoDia = pIdTipoDia;
            this.IdPlazoEntegra = pIdPlazoEntegra;
            this.PlazoEntregaCantidad = pPlazoEntregaCantidad;
            this.FechaLimite = pFechaLimite;
            this.IdTipoEntrega = pIdTipoEntrega;
            this.Observaciones = pObservaciones;
            this.NotaEspecial = pNotaEspecial;
            this.IdEstatus = pIdEstatus;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
            this.FechaRegistro = pFechaRegistro;
            this.IdPlazoTiempo = pIdPlazoTiempo;
            this.IsNUll = pIsNUll;
        }


    }
}
