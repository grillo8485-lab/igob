using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEstatusPersonas {

	public int IdEstatusPersona { get; set;}
	public string Estatus { get; set;}
	public bool Activo { get; set;}

	public beEstatusPersonas()
	{
		
	}

	public beEstatusPersonas( int pIdEstatusPersona, string pEstatus, bool pActivo)
	{
		this.IdEstatusPersona = pIdEstatusPersona;
		this.Estatus = pEstatus;
		this.Activo = pActivo;
	}


}
}
