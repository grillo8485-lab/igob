using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beListadoLicitacionesInvitacionProveedores
    {
        public int IdInvitacion { get; set; }
        public int IdLicitacion { get; set; }
        public int IdProveedor { get; set; }
        public bool Aceptacion { get; set; }
        public DateTime FechaAceptacion { get; set; }
        public string UrlRecibo { get; set; }
        public string Observaciones { get; set; }
        public int IdEstatusPago { get; set; }
        //Licitaciones
        public DateTime FechaAutorizacion { get; set; }
        public TimeSpan HoraAutorizacion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaDisposicionBases { get; set; }
        public DateTime FechaLimitePreguntas { get; set; }
        public DateTime FechaLimiteRespuestas { get; set; }
        public DateTime FechaHoraAclaracionDudas { get; set; }
        public DateTime FechaEnvioPropuestasTecEco { get; set; }
        public DateTime FechaLimiteDictamen { get; set; }
        public DateTime FechaFallo { get; set; }
        public TimeSpan HoraFallo { get; set; }
        public string FolioOficial { get; set; }
        //Tiempos
        public string Tiempo { get; set; }
        //EjerciciosFiscales
        public int Ejercicio { get; set; }
        //Dependencias/Partidas
        public string Partidas { get; set; }
        public string Dependencias { get; set; }
        //Nuevo Campo ?
        public int FolioNumero { get; set; }
        public string ModalidadLicitacion { get; set; }
        public string Licitacion { get; set; }
        public string FolioPago { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaValidoPago { get; set; }
        public string Estatus { get; set; }
        public string RazonSocial { get; set; }
        // seccion para validar campos 
        public bool IsNUllPago { get; set; }
        public bool IsNUllFechaJuntaAclaracionDudas { get; set; }
        public int IdEstatusEnvioPropuestaEconomica { get; set; }
        public int IdEstatusEnvioPropuestaTecnica { get; set; }
        public int IdEstatusLicitacion { get; set; }
        public string EstatusLicitacion { get; set; }
        public int PagoRecepcionado { get; set; }
        public beListadoLicitacionesInvitacionProveedores() {
            this.IsNUllPago = false;
            this.IsNUllFechaJuntaAclaracionDudas = false;
        }

        public beListadoLicitacionesInvitacionProveedores(int pIdInvitacion, int pIdLicitacion, int pIdProveedor, bool pAceptacion, DateTime pFechaAceptacion, string pUrlRecibo, string pObservaciones, int pIdEstatusPago, DateTime pFechaAutorizacion, TimeSpan pHoraAutorizacion, DateTime pFechaPublicacion, DateTime pFechaDisposicionBases, DateTime pFechaLimitePreguntas, DateTime pFechaLimiteRespuestas, DateTime pFechaHoraAclaracionDudas, DateTime pFechaEnvioPropuestasTecEco, DateTime pFechaLimiteDictamen, DateTime pFechaFallo, TimeSpan pHoraFallo, string pFolioOficial, string pTiempo, int pEjercicio, string pPartidas, string pDependencias, int pFolioNumero, string pFolioPago, DateTime pFechaPago, DateTime pFechaValidoPago)
        {
            this.IdInvitacion = pIdInvitacion;
            this.IdLicitacion = pIdLicitacion;
            this.IdProveedor = pIdProveedor;
            this.Aceptacion = pAceptacion;
            this.FechaAceptacion = pFechaAceptacion;
            this.UrlRecibo = pUrlRecibo;
            this.Observaciones = pObservaciones;
            this.IdEstatusPago = pIdEstatusPago;
            this.FechaAutorizacion = pFechaAutorizacion;
            this.HoraAutorizacion = pHoraAutorizacion;
            this.FechaPublicacion = pFechaPublicacion;
            this.FechaDisposicionBases = pFechaDisposicionBases;
            this.FechaLimitePreguntas = pFechaLimitePreguntas;
            this.FechaLimiteRespuestas = pFechaLimiteRespuestas;
            this.FechaHoraAclaracionDudas = pFechaHoraAclaracionDudas;
            this.FechaEnvioPropuestasTecEco = pFechaEnvioPropuestasTecEco;
            this.FechaLimiteDictamen = pFechaLimiteDictamen;
            this.FechaFallo = pFechaFallo;
            this.HoraFallo = pHoraFallo;
            this.FolioOficial = pFolioOficial;
            this.Tiempo = pTiempo;
            this.Ejercicio = pEjercicio;
            this.Partidas = pPartidas;
            this.Dependencias = pDependencias;
            this.FolioNumero = pFolioNumero;
            this.FolioPago = pFolioPago;
            this.FechaPago = pFechaPago;
            this.FechaValidoPago = pFechaValidoPago;
        }
    }
}
