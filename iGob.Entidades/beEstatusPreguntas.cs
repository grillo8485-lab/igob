using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEstatusPreguntas {

	public int IdEstatusPregunta { get; set;}
	public string Estatus { get; set;}
	public bool Activo { get; set;}

	public beEstatusPreguntas()
	{
		
	}

	public beEstatusPreguntas( int pIdEstatusPregunta, string pEstatus, bool pActivo)
	{
		this.IdEstatusPregunta = pIdEstatusPregunta;
		this.Estatus = pEstatus;
		this.Activo = pActivo;
	}


}
}
