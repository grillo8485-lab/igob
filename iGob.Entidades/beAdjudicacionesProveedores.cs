using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beAdjudicacionesProveedores {

        public int IdAdjudicacionProveedor { get; set; }
        public int IdAdjudicacion { get; set; }
        public int IdProveedor { get; set; }
        public int IdEstatusEnvioPropuestaTecnica { get; set; }
        public int IdUsuaroEnviaPropuestaTecnica { get; set; }
        public DateTime FechaEnvioPropuestaTecnica { get; set; }
        public int IdEstatusEnvioPropuestaEconomica { get; set; }
        public int IdUsuaroEnviaPropuestaEconomica { get; set; }
        public int IdEstatusAdjudicacionProveedor { get; set; }
        public DateTime FechaEnvioPropuestaEconomica { get; set; }
        public bool CartasDependenciaCumple { get; set; }
        public string CartaFundamento { get; set; }
        public bool CartaAdquisicionCumple { get; set; }
        public string CartasAdqObservacion { get; set; }
        public bool CondicionEntregaDependenciaCumple { get; set; }
        public string CondicionEntregaFundamento { get; set; }
        public bool CondicionEntregaAdquisicionCumple { get; set; }
        public string CondicionEntregaAdqObservacion { get; set; }
        public bool CondicionPagoDependenciaCumple { get; set; }
        public string CondicionPagoFundamento { get; set; }
        public bool CondicionPagoAdquisicionCumple { get; set; }
        public string CondicionPagoAdqObservacion { get; set; }
        public bool ManifiestoDependenciaCumple { get; set; }
        public string ManifiestoFundamento { get; set; }
        public bool ManifiestoAdquisicionCumple { get; set; }
        public string ManifiestoAdqObservacion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool ValidaLotesRevisor { get; set; }
        public string ObservacionConEntregaRevisor { get; set; }
        public bool ValidaCondicionEntregaRevisor { get; set; }
        public string ObservacionCondPagoRevisor { get; set; }
        public bool ValidaCondicionPagoRevisor { get; set; }
        public string ObservacionDoctosRevisor { get; set; }
        public bool ValidaDocumentosRevisor { get; set; }

        public string RazonSocial { get; set; }
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
        public string DescripcionOrigenRecurso { get; set; }
        public string TipoAdjudicacion { get; set; }
        public string TipoSolicitud { get; set; }
        public string DescripcionTiposSolicitud { get; set; }
        public string AbreviaturaTiposSolicitud { get; set; }
        public string EstatusAdjudicacion { get; set; }
        public string Dependencia { get; set; }
        public string AbreviaturaDependencias { get; set; }
        public int IdGobierno { get; set; }
        public int IdCapitulo { get; set; }
        public string Partida { get; set; }
        public string Capitulo { get; set; }
        public int Ejercicio { get; set; }

        public decimal MontoAproximadoAutorizado { get; set; }
        public decimal ImporteTotalLotes { get; set; }

        public bool isApprove { get; set; }

        public beAdjudicacionesProveedores()
	{
		
	}

	public beAdjudicacionesProveedores( int pIdAdjudicacionProveedor, int pIdAdjudicacion, int pIdProveedor, int pIdEstatusEnvioPropuestaTecnica, int pIdUsuaroEnviaPropuestaTecnica, DateTime pFechaEnvioPropuestaTecnica, int pIdEstatusEnvioPropuestaEconomica, int pIdUsuaroEnviaPropuestaEconomica, int pIdEstatusAdjudicacionProveedor, DateTime pFechaEnvioPropuestaEconomica, bool pCartasDependenciaCumple, string pCartaFundamento, bool pCartaAdquisicionCumple, string pCartasAdqObservacion, bool pCondicionEntregaDependenciaCumple, string pCondicionEntregaFundamento, bool pCondicionEntregaAdquisicionCumple, string pCondicionEntregaAdqObservacion, bool pCondicionPagoDependenciaCumple, string pCondicionPagoFundamento, bool pCondicionPagoAdquisicionCumple, string pCondicionPagoAdqObservacion, bool pManifiestoDependenciaCumple, string pManifiestoFundamento, bool pManifiestoAdquisicionCumple, string pManifiestoAdqObservacion, int pIdUsuarioRegistro, DateTime pFechaRegistro, bool pValidaLotesRevisor, string pObservacionConEntregaRevisor, bool pValidaCondicionEntregaRevisor, string pObservacionCondPagoRevisor, bool pValidaCondicionPagoRevisor, string pObservacionDoctosRevisor, bool pValidaDocumentosRevisor,
            string pRazonSocial,
    int pIdDependencia,
    int pIdTipoAdjudicacion,
    int pIdTipoSolicitud,
    int pIdOrigenRecurso,
    int pIdOrigenRecursoAutorizado,
    int pIdEstatus,
    int pIdEstatusAdjudicacion,
    int pIdPartida,
    int pIdEjercicioFiscal,
    int pIdPresupuestoPartida,
    string pDescripcionOrigenRecurso,
    string pTipoAdjudicacion,
    string pTipoSolicitud,
    string pDescripcionTiposSolicitud,
    string pAbreviaturaTiposSolicitud,
    string pEstatusAdjudicacion,
    string pDependencia,
    string pAbreviaturaDependencias,
    int pIdGobierno,
    int pIdCapitulo,
    string pPartida,
    string pCapitulo,
    int pEjercicio,
    
    decimal pMontoAproximadoAutorizado,
    decimal pImporteTotalLotes,
    bool pisApprove
    )
        {
		this.IdAdjudicacionProveedor = pIdAdjudicacionProveedor;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdProveedor = pIdProveedor;
		this.IdEstatusEnvioPropuestaTecnica = pIdEstatusEnvioPropuestaTecnica;
		this.IdUsuaroEnviaPropuestaTecnica = pIdUsuaroEnviaPropuestaTecnica;
		this.FechaEnvioPropuestaTecnica = pFechaEnvioPropuestaTecnica;
		this.IdEstatusEnvioPropuestaEconomica = pIdEstatusEnvioPropuestaEconomica;
		this.IdUsuaroEnviaPropuestaEconomica = pIdUsuaroEnviaPropuestaEconomica;
		this.IdEstatusAdjudicacionProveedor = pIdEstatusAdjudicacionProveedor;
		this.FechaEnvioPropuestaEconomica = pFechaEnvioPropuestaEconomica;
		this.CartasDependenciaCumple = pCartasDependenciaCumple;
		this.CartaFundamento = pCartaFundamento;
		this.CartaAdquisicionCumple = pCartaAdquisicionCumple;
		this.CartasAdqObservacion = pCartasAdqObservacion;
		this.CondicionEntregaDependenciaCumple = pCondicionEntregaDependenciaCumple;
		this.CondicionEntregaFundamento = pCondicionEntregaFundamento;
		this.CondicionEntregaAdquisicionCumple = pCondicionEntregaAdquisicionCumple;
		this.CondicionEntregaAdqObservacion = pCondicionEntregaAdqObservacion;
		this.CondicionPagoDependenciaCumple = pCondicionPagoDependenciaCumple;
		this.CondicionPagoFundamento = pCondicionPagoFundamento;
		this.CondicionPagoAdquisicionCumple = pCondicionPagoAdquisicionCumple;
		this.CondicionPagoAdqObservacion = pCondicionPagoAdqObservacion;
		this.ManifiestoDependenciaCumple = pManifiestoDependenciaCumple;
		this.ManifiestoFundamento = pManifiestoFundamento;
		this.ManifiestoAdquisicionCumple = pManifiestoAdquisicionCumple;
		this.ManifiestoAdqObservacion = pManifiestoAdqObservacion;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.ValidaLotesRevisor = pValidaLotesRevisor;
		this.ObservacionConEntregaRevisor = pObservacionConEntregaRevisor;
		this.ValidaCondicionEntregaRevisor = pValidaCondicionEntregaRevisor;
		this.ObservacionCondPagoRevisor = pObservacionCondPagoRevisor;
		this.ValidaCondicionPagoRevisor = pValidaCondicionPagoRevisor;
		this.ObservacionDoctosRevisor = pObservacionDoctosRevisor;
		this.ValidaDocumentosRevisor = pValidaDocumentosRevisor;

        this.RazonSocial = pRazonSocial;
        this.IdDependencia = pIdDependencia;
        this.IdTipoAdjudicacion = pIdTipoAdjudicacion;
        this.IdTipoSolicitud = pIdTipoAdjudicacion;
        this.IdOrigenRecurso = pIdTipoSolicitud;
        this.IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
        this.IdEstatus = pIdEstatus;
        this.IdEstatusAdjudicacion = pIdEstatusAdjudicacion;
        this.IdPartida = pIdPartida;
        this.IdEjercicioFiscal = pIdEjercicioFiscal;
        this.IdPresupuestoPartida = pIdPresupuestoPartida;
        this.DescripcionOrigenRecurso = pDescripcionOrigenRecurso;
        this.TipoAdjudicacion = pTipoAdjudicacion;
        this.TipoSolicitud = pTipoSolicitud;
        this.DescripcionTiposSolicitud = pDescripcionTiposSolicitud;
        this.AbreviaturaTiposSolicitud = pAbreviaturaTiposSolicitud;
        this.EstatusAdjudicacion = pEstatusAdjudicacion;
        this.Dependencia = pDependencia;
        this.AbreviaturaDependencias = pAbreviaturaDependencias;
        this.IdGobierno = pIdGobierno;
        this.IdCapitulo = pIdCapitulo;
        this.Partida = pPartida;
        this.Capitulo = pCapitulo;
        this.Ejercicio = pEjercicio;

        this.MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
        this.ImporteTotalLotes = pImporteTotalLotes;

        this.isApprove = pisApprove;

    }


}
}
