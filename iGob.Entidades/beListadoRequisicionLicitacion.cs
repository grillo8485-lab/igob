using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beListadoRequisicionLicitacion
    {
        public int IdRequisicion { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int NumeroLicitacion { get; set; }
        public string NumeroLicitacionT { get; set; }
        public int IdTiempo { get; set; }
        public int IdFormaAbastecimiento { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public int IdPresupuestoPartida { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int ConsecutivoRequisicion { get; set; }
        public string NumeroOficioSolicitud { get; set; }
        public string NumeroOficioCertificacion { get; set; }
        public decimal MontoAproximadoAutorizado { get; set; }
        public string ClavePartida { get; set; }
        public string Partida { get; set; }
        public int IdCapitulo { get; set; }
        public int ClaveCapitulo { get; set; }
        public string Capitulo { get; set; }
        public string OrigenRecurso { get; set; }
        public string FormaAbastecimiento { get; set; }
        public string Tiempo { get; set; }
        public string TipoSolicitud { get; set; }
        public int Ejercicio { get; set; }
        public int IdProveedorRqInvitacion { get; set; }
        public int IdEstatusEnvioPropuestaEconomica { get; set; }
        public int IdEstatusEnvioPropuestaTecnica { get; set; }

        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string EstatusPropuestaTecnica { get; set; }
        public string EstatusPropuestaEconomica { get; set; }

        public beListadoRequisicionLicitacion()
        {

        }

    }
}
