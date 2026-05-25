using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresPreguntas {

	public int IdPregunta { get; set;}
	public int IdProveedorRqInvitacion { get; set;}
	public int NoPregunta { get; set;}
	public string Pregunta { get; set;}
	public int IdEstatusPregunta { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdUsuarioRegistro { get; set;}

	public beProveedoresPreguntas()
	{
		
	}

	public beProveedoresPreguntas( int pIdPregunta, int pIdProveedorRqInvitacion, int pNoPregunta, string pPregunta, int pIdEstatusPregunta, DateTime pFechaRegistro, int pIdUsuarioRegistro)
	{
		this.IdPregunta = pIdPregunta;
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.NoPregunta = pNoPregunta;
		this.Pregunta = pPregunta;
		this.IdEstatusPregunta = pIdEstatusPregunta;
		this.FechaRegistro = pFechaRegistro;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
	}


}
}
