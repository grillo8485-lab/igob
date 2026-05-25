using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionesModalidades
    {

	public int IdConfiguracionModalidad { get; set;}
	public int IdGobierno { get; set;}
	public int IdTiempo { get; set;}
	public int IdTipoLicitacion { get; set;}
	public int IdModalidadLicitacion { get; set;}
	public int PublicacionConvocatoriaDia { get; set;}
	public int DisposicionBasesDias { get; set;}
	public int LimiteEnvioPreguntasHoras { get; set;}
	public int LimiteEnvioRespuestasHoras { get; set;}
	public int AclaracionDudasDias { get; set;}
	public int EnvioProuestaTecEcoDias { get; set;}
	public int EntregaDictamenDias { get; set;}
	public int FalloDias { get; set;}
	public int CantidadLotesLicitacion { get; set;}
	public int CantidadLotesRequiscion { get; set;}
	public int NumeroPujas { get; set;}
	public int MnimoProveedores { get; set;}
	public string NomenclaturaProveedores { get; set;}
	public string NomenclaturaPreguntas { get; set;}
    public string Tiempo { get; set; }
    public string TipoLicitacion { get; set; }
        public string ModalidadesLicitaciones { get; set; }
        public beConfiguracionesModalidades()
	{
		
	}

	public beConfiguracionesModalidades( int pIdConfiguracionModalidad, int pIdGobierno, int pIdTiempo, int pIdTipoLicitacion, int pIdModalidadLicitacion, int pPublicacionConvocatoriaDia, int pDisposicionBasesDias, int pLimiteEnvioPreguntasHoras, int pLimiteEnvioRespuestasHoras, int pAclaracionDudasDias, int pEnvioProuestaTecEcoDias, int pEntregaDictamenDias, int pFalloDias, int pCantidadLotesLicitacion, int pCantidadLotesRequiscion, int pNumeroPujas, int pMnimoProveedores, string pNomenclaturaProveedores, string pNomenclaturaPreguntas)
	{
		this.IdConfiguracionModalidad = pIdConfiguracionModalidad;
		this.IdGobierno = pIdGobierno;
		this.IdTiempo = pIdTiempo;
		this.IdTipoLicitacion = pIdTipoLicitacion;
		this.IdModalidadLicitacion = pIdModalidadLicitacion;
		this.PublicacionConvocatoriaDia = pPublicacionConvocatoriaDia;
		this.DisposicionBasesDias = pDisposicionBasesDias;
		this.LimiteEnvioPreguntasHoras = pLimiteEnvioPreguntasHoras;
		this.LimiteEnvioRespuestasHoras = pLimiteEnvioRespuestasHoras;
		this.AclaracionDudasDias = pAclaracionDudasDias;
		this.EnvioProuestaTecEcoDias = pEnvioProuestaTecEcoDias;
		this.EntregaDictamenDias = pEntregaDictamenDias;
		this.FalloDias = pFalloDias;
		this.CantidadLotesLicitacion = pCantidadLotesLicitacion;
		this.CantidadLotesRequiscion = pCantidadLotesRequiscion;
		this.NumeroPujas = pNumeroPujas;
		this.MnimoProveedores = pMnimoProveedores;
		this.NomenclaturaProveedores = pNomenclaturaProveedores;
		this.NomenclaturaPreguntas = pNomenclaturaPreguntas;
	}


}
}
