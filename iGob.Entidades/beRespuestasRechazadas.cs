using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRespuestasRechazadas {

	public int IdRespuestaRechazada { get; set;}
	public int IdRespuesta { get; set;}
	public int IdPregunta { get; set;}
	public int IdEstatusRespuesta { get; set;}
	public string Respuesta { get; set;}
	public string Observaciones { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRespuestasRechazadas()
	{
		
	}

	public beRespuestasRechazadas( int pIdRespuestaRechazada, int pIdRespuesta, int pIdPregunta, int pIdEstatusRespuesta, string pRespuesta, string pObservaciones, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdRespuestaRechazada = pIdRespuestaRechazada;
		this.IdRespuesta = pIdRespuesta;
		this.IdPregunta = pIdPregunta;
		this.IdEstatusRespuesta = pIdEstatusRespuesta;
		this.Respuesta = pRespuesta;
		this.Observaciones = pObservaciones;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}
