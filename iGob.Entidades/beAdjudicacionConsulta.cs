using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iGob.Entidades
{
    public class beAdjudicacionConsulta
    {
        public int IdAdjudicacion{ get; set; }
     
        public int IdDependencia { get; set; }
        public int IdTipoAdjudicacion { get; set; }
        public int IdTipoSolicitud { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int IdOrigenRecursoAutorizado { get; set; }
        public int IdEstatus { get; set; }
        public int IdEstatusAdjudicacion { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public int IdPresupuestoPartida { get; set; }
        public DateTime FechaAdjudicacion { get; set; }
        public string AdjudicacionFolio { get; set; }
        public int ConsecutivoAdjudicacion { get; set; }
        public string NumeroOficioSolicitud { get; set; }
        public string NumeroOficioCertificacion { get; set; }
        public decimal MontoAproximadoAutorizado { get; set; }
        public decimal MontoAproximado { get; set; }
        public int CantidadLotes { get; set; }
        public decimal ImporteTotalLotes { get; set; }
        public string Observaciones { get; set; }
        public string Justificacion { get; set; }
        public decimal SaldoPartida { get; set; }
        public decimal MontoPresupuestado { get; set; }
        public int IdUsuarioAsignante { get; set; }
        public int Acepta2daLicitacion { get; set; }
        public int IdUsuarioRevisor { get; set; }
        public DateTime FechaAsignaRevisor { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public decimal Economia { get; set; }
        public int Ejercicio { get; set; }
        public string OrigenRecurso { get; set; }
        public decimal Ejercido { get; set; }
        public string DescripcionOrigenRecurso { get; set; }
        public string TipoAdjudicacion { get; set; }
        public string TipoSolicitud { get; set; }
        public string DescripcionTiposSolicitud { get; set; }
        public string AbreviaturaTiposSolicitud { get; set; }
        public int EstatusAdjudicacion { get; set; }
        public string Dependencia { get; set; }
        public string AbreviaturaDependencias { get; set; }
        public int IdGobierno { get; set; }
        public int IdCapitulo { get; set; }        
        public string Partida { get; set; }
        public string Capitulo { get; set; }
        public string Estatus { get; set; }

        public int IdEstatusEnvioPropuestaTecnica { get; set; }
        public int IdEstatusEnvioPropuestaEconomica { get; set; }

        public beAdjudicacionConsulta()
        {

        }

        public beAdjudicacionConsulta(int pIdAdjudicacion, int pIdDependencia, int pIdTipoAdjudicacion, int pIdTipoSolicitud, int pIdOrigenRecurso, int pIdOrigenRecursoAutorizado, int pIdEstatus, int pIdEstatusAdjudicacion,
            int pIdPartida, int pIdEjercicioFiscal, int pIdPresupuestoPartida, DateTime pFechaAdjudicacion, string pAdjudicacionFolio, int pConsecutivoAdjudicacion, string pNumeroOficioSolicitud, string pNumeroOficioCertificacion, decimal pMontoAproximadoAutorizado,
            decimal pMontoAproximado, int pCantidadLotes, decimal pImporteTotalLotes, string pObservaciones, string pJustificacion, int pSaldoPartida, int pMontoPresupuestado, int pIdUsuarioAsignante, int pAcepta2daLicitacion, int pIdUsuarioRevisor, DateTime pFechaAsignaRevisor,
            DateTime pFechaAutorizacion, int pEconomia, int pEjercido,int pEjercicio, string pOrigenRecurso, string pDescripcionOrigenRecurso, string pTipoAdjudicacion, string pTipoSolicitud, string pDescripcionTiposSolicitud, string pAbreviaturaTiposSolicitud, int pEstatusAdjudicacion,
            string pDependencia, string pAbreviaturaDependencias, int pIdGobierno, int pIdCapitulo, string pPartida, string pCapitulo , string pEstatus, int pIdEstatusEnvioPropuestaTecnica, int pIdEstatusEnvioPropuestaEconomica)
        {
                IdAdjudicacion = pIdAdjudicacion;
                IdDependencia = pIdDependencia;
                IdTipoAdjudicacion = pIdTipoAdjudicacion;
                IdTipoSolicitud = pIdTipoSolicitud;
                IdOrigenRecurso = pIdOrigenRecurso;
                IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
                IdEstatus = pIdEstatus;
                IdEstatusAdjudicacion = pIdEstatusAdjudicacion;
                IdPartida = pIdPartida;
                IdEjercicioFiscal = pIdEjercicioFiscal;
                IdPresupuestoPartida = pIdPresupuestoPartida;
                FechaAdjudicacion = pFechaAdjudicacion;
                AdjudicacionFolio = pAdjudicacionFolio;
                ConsecutivoAdjudicacion = pConsecutivoAdjudicacion;
                NumeroOficioSolicitud = pNumeroOficioSolicitud;
                NumeroOficioCertificacion = pNumeroOficioCertificacion;
                MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
                MontoAproximado = pMontoAproximado;
                CantidadLotes = pCantidadLotes;
                ImporteTotalLotes = pImporteTotalLotes;
                Observaciones = pObservaciones;
                Justificacion = pJustificacion;
                SaldoPartida = pSaldoPartida;
                MontoPresupuestado = pMontoPresupuestado;
                IdUsuarioAsignante = pIdUsuarioAsignante;
                Acepta2daLicitacion = pAcepta2daLicitacion;
                IdUsuarioRevisor = pIdUsuarioRevisor;
                FechaAsignaRevisor = pFechaAsignaRevisor;
                FechaAutorizacion = pFechaAutorizacion;
                Economia = pEconomia;
                Ejercido = pEjercido;
                OrigenRecurso = pOrigenRecurso;
                DescripcionOrigenRecurso = pDescripcionOrigenRecurso;
                TipoAdjudicacion = pTipoAdjudicacion;
                TipoSolicitud = pTipoSolicitud;
                DescripcionTiposSolicitud = pDescripcionTiposSolicitud;
                AbreviaturaTiposSolicitud = pAbreviaturaTiposSolicitud;
                EstatusAdjudicacion = pEstatusAdjudicacion;
                Dependencia = pDependencia;
                AbreviaturaDependencias = pAbreviaturaDependencias;
                IdGobierno = pIdGobierno;
                IdCapitulo = pIdCapitulo;
                Partida = pPartida;
                Capitulo = pCapitulo;
                Estatus = pEstatus;
                Ejercicio = pEjercicio;
                IdEstatusEnvioPropuestaTecnica = pIdEstatusEnvioPropuestaTecnica;
                IdEstatusEnvioPropuestaEconomica = pIdEstatusEnvioPropuestaEconomica;
        }
    }
}