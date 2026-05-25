using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{

    public class beRequisicionConsulta
    {
        public int IdRequisicion { get; set; }
        public int IdRequisicionOrigen { get; set; }
        public int IdDependencia { get; set; }
        public int IdTipoRequisicion { get; set; }
        public int IdTipoSolicitud { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int IdOrigenRecursoAutorizado { get; set; }
        public int IdEstatus { get; set; }
        public int IdEstatusRequisicion { get; set; }
        public int NumeroLicitacion { get; set; }
        public int IdTiempo { get; set; }
        public int IdFormaAbastecimiento { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int ConsecutivoRequisicion { get; set; }
        public string NumeroOficioSolicitud { get; set; }
        public string NumeroOficioCertificacion { get; set; }
        public decimal MontoAproximadoAutorizado { get; set; }
        public decimal MontoAproximado { get; set; }
        public int CantidadLotes { get; set; }
        public decimal ImporteTotalLotes { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesRechazo { get; set; }
        public TimeSpan TiempoRestante { get; set; }
        public string OrigenRecurso { get; set; }
        public string DescripcionOrigenRecurso { get; set; }
        public string TipoRequisicion { get; set; }
        public string Tiempo { get; set; }
        public string TipoSolicitud { get; set; }
        public string DescripcionTiposSolicitud { get; set; }
        public string AbreviaturaTiposSolicitud { get; set; }
        public string Estatus { get; set; }
        public string Dependencia { get; set; }
        public string AbreviaturaDependencias { get; set; }
        public int IdGobierno { get; set; }
        public int IdCapitulo { get; set; }
        public string Capitulo { get; set; }
        public string Partida { get; set; }
        public string FormaAbastecimiento { get; set; }
        public int Ejercicio { get; set; }
        public int IdUsuarioRevisor { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string NumeroLicitacionT { get; set; }
       public string ColorTiempoRestante { get; set; }
        public beRequisicionConsulta()
        {

        }
        public beRequisicionConsulta(int pIdRequisicion
, int pIdRequisicionOrigen
, int pIdDependencia
, int pIdTipoRequisicion
, int pIdTipoSolicitud
, int pIdOrigenRecurso
, int pIdOrigenRecursoAutorizado
, int pIdEstatus
, int pIdEstatusRequisicion
, int pNumeroLicitacion
, int pIdTiempo
, int pIdFormaAbastecimiento
, int pIdPartida
, int pIdEjercicioFiscal
, DateTime pFechaRequisicion
, string pRequisicionFolio
, int pConsecutivoRequisicion
, string pNumeroOficioSolicitud
, string pNumeroOficioCertificacion
, decimal pMontoAproximadoAutorizado
, decimal pMontoAproximado
, int pCantidadLotes
, decimal pImporteTotalLotes
, string pObservaciones
, string pObservacionesRechazo
, TimeSpan pTiempoRestante
, string pOrigenRecurso
, string pDescripcionOrigenRecurso
, string pTipoRequisicion
, string pTiempo
, string pTipoSolicitud
, string pDescripcionTiposSolicitud
, string pAbreviaturaTiposSolicitud
, string pEstatus
, string pDependencia
, string pAbreviaturaDependencias
, int pIdGobierno
, int pIdCapitulo
, string pCapitulo
, string pPartida,
            string pFormaAbastecimiento,
            int pEjercicio,
            int pIdUsuarioRevisor,
            int pIdUsuarioRegistro)
        {
            this.IdRequisicion = pIdRequisicion;
            this.IdRequisicionOrigen = pIdRequisicionOrigen;
            this.IdDependencia = pIdDependencia;
            this.IdTipoRequisicion = pIdTipoRequisicion;
            this.IdTipoSolicitud = pIdTipoSolicitud;
            this.IdOrigenRecurso = pIdOrigenRecurso;
            this.IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
            this.IdEstatus = pIdEstatus;
            this.IdEstatusRequisicion = pIdEstatusRequisicion;
            this.NumeroLicitacion = pNumeroLicitacion;
            this.IdTiempo = pIdTiempo;
            this.IdFormaAbastecimiento = pIdFormaAbastecimiento;
            this.IdPartida = pIdPartida;
            this.IdEjercicioFiscal = pIdEjercicioFiscal;
            this.FechaRequisicion = pFechaRequisicion;
            this.RequisicionFolio = pRequisicionFolio;
            this.ConsecutivoRequisicion = pConsecutivoRequisicion;
            this.NumeroOficioSolicitud = pNumeroOficioSolicitud;
            this.NumeroOficioCertificacion = pNumeroOficioCertificacion;
            this.MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
            this.MontoAproximado = pMontoAproximado;
            this.CantidadLotes = pCantidadLotes;
            this.ImporteTotalLotes = pImporteTotalLotes;
            this.Observaciones = pObservaciones;
            this.ObservacionesRechazo = pObservacionesRechazo;
            this.TiempoRestante = pTiempoRestante;
            this.OrigenRecurso = pOrigenRecurso;
            this.DescripcionOrigenRecurso = pDescripcionOrigenRecurso;
            this.TipoRequisicion = pTipoRequisicion;
            this.Tiempo = pTiempo;
            this.TipoSolicitud = pTipoSolicitud;
            this.DescripcionTiposSolicitud = pDescripcionTiposSolicitud;
            this.AbreviaturaTiposSolicitud = pAbreviaturaTiposSolicitud;
            this.Estatus = pEstatus;
            this.Dependencia = pDependencia;
            this.AbreviaturaDependencias = pAbreviaturaDependencias;
            this.IdGobierno = pIdGobierno;
            this.IdCapitulo = pIdCapitulo;
            this.Capitulo = pCapitulo;
            this.Partida = pPartida;
            this.Partida = pPartida;
            this.FormaAbastecimiento = pFormaAbastecimiento;
            this.Ejercicio = pEjercicio;
            this.IdUsuarioRevisor = pIdUsuarioRevisor;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
        }
    }
}
