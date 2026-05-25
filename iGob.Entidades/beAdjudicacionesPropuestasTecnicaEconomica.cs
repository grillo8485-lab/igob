using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesPropuestasTecnicaEconomica {

	public int IdAdjudicionPropuestaTecEco { get; set;}
	public int IdAdjudicacionProveedor { get; set;}
	public int IdLote { get; set;}
	public string Mejora { get; set;}
	public int EstatusMejora { get; set;}
	public decimal PrecioUnitarioRefencia { get; set;}
	public decimal PrecioUnitarioOfertado { get; set;}
	public decimal ImporteOfertado { get; set;}
	public decimal ImpuestoPorcentaje { get; set;}
	public decimal ImpuestoImporte { get; set;}
	public decimal TotalOfertado { get; set;}
	public int IdEstatusPropuesta { get; set;}
	public string URLFileMuestraCatalogo { get; set;}
	public string URLFileCertificacion { get; set;}
	public int DependenciaCumple { get; set;}
	public string FundamentoLegal { get; set;}
	public int AdquisicionCumple { get; set;}
	public string AdquisicionObserva { get; set;}
	public int ProveedorGanador { get; set;}
	public int ValidaEconomica { get; set;}
	public decimal ImportePeriodo { get; set;}
	public decimal ImpuestoPeriodo { get; set;}
	public decimal TotalPeriodo { get; set;}
	public int IdMesInicial { get; set;}
	public int IdMesFinal { get; set;}

    public int IdAdjudicacion { get; set; }

    public int IdProveedor { get; set; }
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

    public int NoLote { get; set; }
    public decimal Cantidad { get; set; }
    public int IdBienServicio { get; set; }
    public string BienServicio { get; set; }
    public int IdUnidadMedida { get; set; }
    public string UnidadMedida { get; set; }
    public string Pantone { get; set; }

    public string DescripcionBienServicio { get; set; }


        public beAdjudicacionesPropuestasTecnicaEconomica()
	{
		
	}

	public beAdjudicacionesPropuestasTecnicaEconomica( int pIdAdjudicionPropuestaTecEco, int pIdAdjudicacionProveedor, int pIdLote, string pMejora, int pEstatusMejora, decimal pPrecioUnitarioRefencia, decimal pPrecioUnitarioOfertado, decimal pImporteOfertado, decimal pImpuestoPorcentaje, decimal pImpuestoImporte, decimal pTotalOfertado, int pIdEstatusPropuesta, string pURLFileMuestraCatalogo, string pURLFileCertificacion, int pDependenciaCumple, string pFundamentoLegal, int pAdquisicionCumple, string pAdquisicionObserva, int pProveedorGanador, int pValidaEconomica, decimal pImportePeriodo, decimal pImpuestoPeriodo, decimal pTotalPeriodo, int pIdMesInicial, int pIdMesFinal, int pIdAdjudicacion,


     int posIdProveedor,
     string posRazonSocial ,
     int posIdDependencia,
     int posIdTipoAdjudicacion,
     int posIdTipoSolicitud,
     int posIdOrigenRecurso,
     int posIdOrigenRecursoAutorizado,
     int posIdEstatus,
     int posIdEstatusAdjudicacion,
     int posIdPartida,
     int posIdEjercicioFiscal,
     int posIdPresupuestoPartida,
     string posDescripcionOrigenRecurso ,
     string posTipoAdjudicacion ,
     string posTipoSolicitud ,
     string posDescripcionTiposSolicitud ,
     string posAbreviaturaTiposSolicitud ,
     string posEstatusAdjudicacion ,
     string posDependencia ,
     string posAbreviaturaDependencias ,
     int posIdGobierno,
     int posIdCapitulo,
     string posPartida ,
     string posCapitulo ,
     int posEjercicio,

     int posNoLote ,
     decimal posCantidad ,
     int posIdBienServicio ,
     string posBienServicio ,
     int posIdUnidadMedida ,
     string posUnidadMedida ,
     string posPantone,

    string posDescripcionBienServicio


        )
	{
		this.IdAdjudicionPropuestaTecEco = pIdAdjudicionPropuestaTecEco;
		this.IdAdjudicacionProveedor = pIdAdjudicacionProveedor;
		this.IdLote = pIdLote;
		this.Mejora = pMejora;
		this.EstatusMejora = pEstatusMejora;
		this.PrecioUnitarioRefencia = pPrecioUnitarioRefencia;
		this.PrecioUnitarioOfertado = pPrecioUnitarioOfertado;
		this.ImporteOfertado = pImporteOfertado;
		this.ImpuestoPorcentaje = pImpuestoPorcentaje;
		this.ImpuestoImporte = pImpuestoImporte;
		this.TotalOfertado = pTotalOfertado;
		this.IdEstatusPropuesta = pIdEstatusPropuesta;
		this.URLFileMuestraCatalogo = pURLFileMuestraCatalogo;
		this.URLFileCertificacion = pURLFileCertificacion;
		this.DependenciaCumple = pDependenciaCumple;
		this.FundamentoLegal = pFundamentoLegal;
		this.AdquisicionCumple = pAdquisicionCumple;
		this.AdquisicionObserva = pAdquisicionObserva;
		this.ProveedorGanador = pProveedorGanador;
		this.ValidaEconomica = pValidaEconomica;
		this.ImportePeriodo = pImportePeriodo;
		this.ImpuestoPeriodo = pImpuestoPeriodo;
		this.TotalPeriodo = pTotalPeriodo;
		this.IdMesInicial = pIdMesInicial;
		this.IdMesFinal = pIdMesFinal;

        this.IdAdjudicacion = pIdAdjudicacion;


        this.IdProveedor = posIdProveedor;
        this.RazonSocial = posRazonSocial;
        this.IdDependencia = posIdDependencia;
        this.IdTipoAdjudicacion = posIdTipoAdjudicacion;
        this.IdTipoSolicitud = posIdTipoSolicitud;
        this.IdOrigenRecurso = posIdOrigenRecurso;
        this.IdOrigenRecursoAutorizado = posIdOrigenRecursoAutorizado;
        this.IdEstatus = posIdEstatus;
        this.IdEstatusAdjudicacion = posIdEstatusAdjudicacion;
        this.IdPartida = posIdPartida;
        this.IdEjercicioFiscal = posIdEjercicioFiscal;
        this.IdPresupuestoPartida = posIdPresupuestoPartida;
        this.DescripcionOrigenRecurso = posDescripcionOrigenRecurso;
        this.TipoAdjudicacion = posTipoAdjudicacion;
        this.TipoSolicitud = posTipoSolicitud;
        this.DescripcionTiposSolicitud = posDescripcionTiposSolicitud;
        this.AbreviaturaTiposSolicitud = posAbreviaturaTiposSolicitud;
        this.EstatusAdjudicacion = posEstatusAdjudicacion;
        this.Dependencia = posDependencia;
        this.AbreviaturaDependencias = posAbreviaturaDependencias;
        this.IdGobierno = posIdGobierno;
        this.IdCapitulo = posIdCapitulo;
        this.Partida = posPartida;
        this.Capitulo = posCapitulo;
        this.Ejercicio = posEjercicio;

        this.NoLote = posNoLote;
        this.Cantidad = posCantidad;
        this.IdBienServicio = posIdBienServicio;
        this.BienServicio = posBienServicio;
        this.IdUnidadMedida = posIdUnidadMedida;
        this.UnidadMedida = posUnidadMedida;
        this.Pantone = posPantone;

        this.DescripcionBienServicio = posDescripcionBienServicio;

    }


}
}
