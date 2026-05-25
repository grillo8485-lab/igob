using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRespuestas {

	public int IdRespuesta { get; set;}
	public int IdPregunta { get; set;}
	public int IdEstatusRespuesta { get; set;}
	public int IdEstatusRespuestaGeneral { get; set;}
	public string Respuesta { get; set;}
	public string Observaciones { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRespuestas()
	{
		
	}

	public beRespuestas( int pIdRespuesta, int pIdPregunta, int pIdEstatusRespuesta, int pIdEstatusRespuestaGeneral, string pRespuesta, string pObservaciones, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdRespuesta = pIdRespuesta;
		this.IdPregunta = pIdPregunta;
		this.IdEstatusRespuesta = pIdEstatusRespuesta;
		this.IdEstatusRespuestaGeneral = pIdEstatusRespuestaGeneral;
		this.Respuesta = pRespuesta;
		this.Observaciones = pObservaciones;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
