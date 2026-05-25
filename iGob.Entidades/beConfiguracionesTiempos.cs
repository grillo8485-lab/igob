using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConfiguracionesTiempos {

	public int IdConfiguracionTiempo { get; set;}
	public int IdGobierno { get; set;}
	public int IdTiempo { get; set;}
	public int IdTipoLicitacion { get; set;}
	public int PublicacionConvocatoriaDia { get; set;}
	public int DisposicionBasesDias { get; set;}
	public int LimiteEnvioPreguntasHoras { get; set;}
	public int LimiteEnvioRespuestasHoras { get; set;}
	public int AclaracionDudasDias { get; set;}
	public int EnvioProuestaTecEcoDias { get; set;}
	public int EntregaDictamenDias { get; set;}
	public int FalloDias { get; set;}
    
    /* Gobierno 24/08/2018 */
    public string Gobierno { get; set;}

	public beConfiguracionesTiempos()
	{
		
	}

	public beConfiguracionesTiempos( int pIdConfiguracionTiempo, int pIdGobierno, int pIdTiempo, int pIdTipoLicitacion, int pPublicacionConvocatoriaDia, int pDisposicionBasesDias, int pLimiteEnvioPreguntasHoras, int pLimiteEnvioRespuestasHoras, int pAclaracionDudasDias, int pEnvioProuestaTecEcoDias, int pEntregaDictamenDias, int pFalloDias)
	{
		this.IdConfiguracionTiempo = pIdConfiguracionTiempo;
		this.IdGobierno = pIdGobierno;
		this.IdTiempo = pIdTiempo;
		this.IdTipoLicitacion = pIdTipoLicitacion;
		this.PublicacionConvocatoriaDia = pPublicacionConvocatoriaDia;
		this.DisposicionBasesDias = pDisposicionBasesDias;
		this.LimiteEnvioPreguntasHoras = pLimiteEnvioPreguntasHoras;
		this.LimiteEnvioRespuestasHoras = pLimiteEnvioRespuestasHoras;
		this.AclaracionDudasDias = pAclaracionDudasDias;
		this.EnvioProuestaTecEcoDias = pEnvioProuestaTecEcoDias;
		this.EntregaDictamenDias = pEntregaDictamenDias;
		this.FalloDias = pFalloDias;
	}


}
}
