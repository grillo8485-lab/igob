using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEstatusEstudioMercado {

	public int IdEstatusEstudioMercado { get; set;}
	public string EstatusEstudioMercado { get; set;}
	public bool Activo { get; set;}

	public beEstatusEstudioMercado()
	{
		
	}

	public beEstatusEstudioMercado( int pIdEstatusEstudioMercado, string pEstatusEstudioMercado, bool pActivo)
	{
		this.IdEstatusEstudioMercado = pIdEstatusEstudioMercado;
		this.EstatusEstudioMercado = pEstatusEstudioMercado;
		this.Activo = pActivo;
	}


}
}
