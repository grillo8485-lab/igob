using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beLicitacionesRequisiciones
    {

        public int IdLicitacionRequisicion { get; set; }
        public int IdLicitacion { get; set; }
        public int IdRequisicion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int Seleccionada { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Dependencia = string.Empty;
        public string Partida = string.Empty;
        public string FolioRequisicion = string.Empty;

        public beLicitacionesRequisiciones()
        {

        }

        public beLicitacionesRequisiciones(int pIdLicitacionRequisicion, int pIdLicitacion, int pIdRequisicion, DateTime pFechaAutorizacion, DateTime pFechaRecepcion, int pSeleccionada, int pIdUsuarioRegistro, DateTime pFechaRegistro,
            string pDependencia, string pPartida, string pFolioRequisicion)
        {
            this.IdLicitacionRequisicion = pIdLicitacionRequisicion;
            this.IdLicitacion = pIdLicitacion;
            this.IdRequisicion = pIdRequisicion;
            this.FechaAutorizacion = pFechaAutorizacion;
            this.FechaRecepcion = pFechaRecepcion;
            this.Seleccionada = pSeleccionada;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
            this.FechaRegistro = pFechaRegistro;
            this.Dependencia = pDependencia;
            this.Partida = pPartida;
            this.FolioRequisicion = pFolioRequisicion;
        }


    }
}
